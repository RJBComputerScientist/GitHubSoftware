import React, {useState, useRef, useEffect} from "react";
import {View, Text, StyleSheet, Alert, ScrollView, FlatList, Dimensions} from 'react-native';
import { Ionicons } from '@expo/vector-icons';

import NumberContainer from "../components/NumberContainer";
import Card from "../components/Card";
import defaultStyles from "../constants/default-styles";
import MainButton from "../components/MainButton";
import BodyText from "../components/BodyText";

const generateRandomBetween = (min, max, exclude) => {
    min = Math.ceil(min);
    max = Math.floor(max);
    const rndnum = Math.floor(Math.random() * (max - min)) + min;
    if(rndnum === exclude){
        return generateRandomBetween(min, max, exclude);
    } else {
        return rndnum;
    }
};

const renderListItem = (value, numOfRound) => (
    // ^^^ for scroll view
// const renderListItem = (listLength, itemData) => (
    // ^^^ for flat list

        <View key={value} style={styles.listItem}>
            <BodyText>#{numOfRound}</BodyText>
            <BodyText>{value}</BodyText>
            {/* ^^ for scroll view */}
            {/* <BodyText>#{listLength - itemData.index}</BodyText>
            <BodyText>{itemData.item}</BodyText> */}
            {/* ^^ for flatlist */}
        </View>
    )

const GameScreen = props => {
    const initialGuess = generateRandomBetween(1, 100, props.userChoice)
    const [currentGuess, setCurrentGuess] = useState(initialGuess);

    const [pastGuesses, setPastGuesses] = useState([initialGuess]);
    // ^^^ for scroll view
    // const [pastGuesses, setPastGuesses] = useState([initialGuess.toString()]);
    // ^^^ for flat list
    const [availableDeviceWidth, setAvailableDeviceWidth] = useState(Dimensions.get('window').width);
    const [availableDeviceHeight, setAvailableDeviceHeight] = useState(Dimensions.get('window').height);
    const CurrentLow = useRef(1);
    const CurrentHigh = useRef(100);

    const { userChoice, onGameOver } = props;

    useEffect(() => {
        const updatedlayout = () => {
            setAvailableDeviceWidth(Dimensions.get('window').width);
            setAvailableDeviceHeight(Dimensions.get('window').height );
        }
        Dimensions.addEventListener('change', updatedlayout);

        return () => {
            Dimensions.removeEventListener('change', updatedlayout)
        }
    })

    useEffect(() => {
        if(currentGuess === userChoice){
            onGameOver(pastGuesses.length);
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
            CurrentLow.current = currentGuess + 1;
        }
        const nextNumber = generateRandomBetween(CurrentLow.current, CurrentHigh.current, currentGuess);
        setCurrentGuess(nextNumber);
        // setRounds(curRounds => curRounds + 1);
        setPastGuesses(curPastGuesses => [nextNumber, ...curPastGuesses])
        // ^^^ for scroll view
        // setPastGuesses(curPastGuesses => [nextNumber.toString(), ...curPastGuesses])
        // ^^^ for flat list
    }

    let listContainerStyle = styles.listContainer;

    if(availableDeviceWidth < 350){
        listContainerStyle = styles.listContainerBig;
    };

    if(availableDeviceHeight < 500){
        return (
            <View style={styles.screen}>
            <Text style={defaultStyles.title}>Opponents Guess</Text>
            <View style={styles.controls}>
            <MainButton  onPress={nextGuessHandler.bind(this, 'lower')} >
                    {/* <Ionicons name="md-remove" size={24} color="white" /> */}
                    {/* ^^ not working for some reason */}
                    LOWER
                </MainButton>
            <NumberContainer>{currentGuess}</NumberContainer>
                <MainButton  onPress={nextGuessHandler.bind(this, 'greater')} >
                    {/* <Ionicons name="md-add" size={24} color="white" /> */}
                    {/* ^^ not working for some reason */}
                    HIGHER
                </MainButton>
                </View>
            {/* <View style={styles.listContainer}> */}
            <View style={listContainerStyle}>
                <ScrollView contentContainerStyle={styles.list}>
                {/*             ^^^ better to use  "contentContainerStyle" for scrollView and Flatlist*/}
                    {pastGuesses.map((guess, index) => renderListItem(guess, pastGuesses.length - index))}
                </ScrollView>
                {/* going with scroll view */}
                {/* <FlatList 
                keyExtractor={(item) => item} 
                data={pastGuesses} 
                renderItem={renderListItem.bind(null, pastGuesses.length)} 
                contentContainerStyle={styles.list}
                /> */}
            </View>
        </View>
        );
    }

    return (
        <View style={styles.screen}>
            <Text style={defaultStyles.title}>Opponents Guess</Text>
            <NumberContainer>{currentGuess}</NumberContainer>
            <Card style={styles.buttonContainer}>
                <MainButton  onPress={nextGuessHandler.bind(this, 'lower')} >
                    {/* <Ionicons name="md-remove" size={24} color="white" /> */}
                    {/* ^^ not working for some reason */}
                    LOWER
                </MainButton>
                <MainButton  onPress={nextGuessHandler.bind(this, 'greater')} >
                    {/* <Ionicons name="md-add" size={24} color="white" /> */}
                    {/* ^^ not working for some reason */}
                    HIGHER
                </MainButton>
            </Card>
            {/* <View style={styles.listContainer}> */}
            <View style={listContainerStyle}>
                <ScrollView contentContainerStyle={styles.list}>
                {/*             ^^^ better to use  "contentContainerStyle" for scrollView and Flatlist*/}
                    {pastGuesses.map((guess, index) => renderListItem(guess, pastGuesses.length - index))}
                </ScrollView>
                {/* going with scroll view */}
                {/* <FlatList 
                keyExtractor={(item) => item} 
                data={pastGuesses} 
                renderItem={renderListItem.bind(null, pastGuesses.length)} 
                contentContainerStyle={styles.list}
                /> */}
            </View>
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
        // marginTop: 30,
        marginTop: Dimensions.get('window').height > 600 ? 30 : 5,
        width: 400,
        maxWidth: '90%'
    },
    listItem: {
        borderColor: 'black',
        padding: 15,
        marginVertical: 10,
        backgroundColor: 'white',
        borderWidth: 1,
        flexDirection: 'row',
        justifyContent: 'space-around',
        width: '80%',
        // ^^ for scroll view
        // width: '100%',
        //^^ for flatlist
    },
    listContainer: {
        // width: Dimensions.get('window').width > 350 ? '80%' : '60%',
        width:'80%',
        // ^^ for scroll view
        // width: '60%',
        // width: Dimensions.get('window').width > 350 ? '60%' : '80%',
        //^^ for flatlist 
        flex: 1
    },
    listContainerBig: {
        flex: 1,
        width: '60%',
        //^^ for scroll view
        // width: '80%',
        //for flatlist 
    },
    list: {
        alignItems: 'center',
        //^^ for scroll view
        justifyContent: 'flex-end',
        flexGrow: 1
    },
    controls: {
        flexDirection: 'row',
        justifyContent: 'space-around',
        width: '80%',
        alignItems: "center"
    },
});

export default GameScreen;