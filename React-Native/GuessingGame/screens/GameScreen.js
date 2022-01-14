import React, {useState, useRef, useEffect} from "react";
import {View, Text, StyleSheet, Button, Alert} from 'react-native';

import NumberContainer from "../components/NumberContainer";
import Card from "../components/Card";
import defaultStyles from "../constants/default-styles";

const generateRandomBetween = (min, max, exclude) => {
    min = Math.ceil(min);
    max = Math.floor(max);
    const rndnum = Math.floor(Math.random() * (max - min)) + min;
    if(rndnum === exclude){
        return generateRandomBetween(min, max, exclude);
    } else {
        return rndnum;
    }
}

const GameScreen = props => {
    const [currentGuess, setCurrentGuess] = useState(generateRandomBetween(1, 100, props.userChoice));

    const [rounds, setRounds] = useState(0);
    const CurrentLow = useRef(1);
    const CurrentHigh = useRef(100);

    const { userChoice, onGameOver } = props;

    useEffect(() => {
        if(currentGuess === userChoice){
            onGameOver(rounds);
        }
    }, [currentGuess, userChoice, onGameOver])

    const nextGuessHandler = direction => {
        if((direction === 'lower' && currentGuess < props.userChoice) || (direction === 'greater' && currentGuess > props.userChoice)){
            Alert.alert('Don\'t Lie', 'You know that this is wrong...', [{text: 'Sorry!', style: 'cancel'}]);
            return;
        }
        if(direction === 'lower'){
            CurrentHigh.current = currentGuess;
        } else {
            CurrentLow.current = currentGuess;
        }
        const nextNumber = generateRandomBetween(CurrentLow.current, CurrentHigh.current, currentGuess);
        setCurrentGuess(nextNumber);
        setRounds(curRounds => curRounds + 1);
    }

    return (
        <View style={styles.screen}>
            <Text style={defaultStyles.title}>Opponents Guess</Text>
            <NumberContainer>{currentGuess}</NumberContainer>
            <Card style={styles.buttonContainer}>
                <Button title="LOWER" onPress={nextGuessHandler.bind(this, 'lower')} />
                <Button title="GREATER" onPress={nextGuessHandler.bind(this, 'greater')} />
            </Card>
        </View>
    )

};

const styles = StyleSheet.create({
    screen: {
        flex: 1,
        padding: 10,
        alignItems: 'center'
    },
    buttonContainer: {
        flexDirection: 'row',
        justifyContent: 'space-around',
        marginTop: 30,
        width: 300,
        maxWidth: '80%'
    },
});

export default GameScreen;