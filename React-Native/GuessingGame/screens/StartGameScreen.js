import React, { useState, useEffect } from "react";
import { View, StyleSheet, Dimensions, Button, TouchableWithoutFeedback, Keyboard, Alert, ScrollView, KeyboardAvoidingView } from "react-native";

import Card from '../components/Card';
import colors from "../constants/colors";
import Input from "../components/Input";
import NumberContainer from "../components/NumberContainer";
import BodyText from "../components/BodyText";
import TitleText from "../components/TitleText";
import MainButton from "../components/MainButton";

const StartGameScreen = props => {
    const [enteredValue, setEnteredValue] = useState('');
    const [confirmed, setConfirmed] = useState(false);
    const [selectedNumber, setSelectedNumber] = useState();
    const [buttonWidth, setButtonWidth] = useState(Dimensions.get('window').width / 4);

    // const updateLayout = () => {
    //     setButtonWidth(Dimensions.get('window').width / 4);
    // }

    // Dimensions.addEventListener('change', updateLayout);
    //^^ asking for update of dimensions
    //^^effiecient to do it like this

    useEffect(() => {
        const updateLayout = () => {
            setButtonWidth(Dimensions.get('window').width / 4);
        }
    
        Dimensions.addEventListener('change', updateLayout);
        return () => {
            Dimensions.removeEventListener('change', updateLayout)
        }
    })

    const numberStored = inputText => {
        setEnteredValue(inputText.replace(/[^0-9]/g, ''));
    };

    const resetINputHandler = () => {
        setEnteredValue('');
        setConfirmed(false);
    };

    const confirmTextHanlder = () => {
        const ChoseNumber = parseInt(enteredValue);
        if(isNaN(ChoseNumber) || ChoseNumber <= 0 || ChoseNumber > 99){
            Alert.alert("Invalid Number", "Number Has To Be a Number Between 1-99", [{text: 'Okay', style: 'destructive', onPress: resetINputHandler}])
            return;
        }
        setConfirmed(true);
        setEnteredValue('');
        setSelectedNumber(ChoseNumber)
        Keyboard.dismiss();
    };

    let confirmedOutput;
    
    if(confirmed){
        confirmedOutput = <Card style={styles.summaryContainer}>
            <BodyText>You Selected</BodyText>
           <NumberContainer>
               {selectedNumber}
           </NumberContainer>
           <MainButton onPress={() => props.onStartGame(selectedNumber)} >
               START GAME
           </MainButton>
        </Card>
    }
    return (
        <ScrollView>
        <KeyboardAvoidingView behavior="position" keyboardVerticalOffset={30}>
        <TouchableWithoutFeedback onPress={() => {
            Keyboard.dismiss();
        }}>
        <View style={styles.screen}>
            <TitleText style={styles.title}>Start A New Game!!</TitleText>
            <Card style={styles.inputContainer}>
                <BodyText>Select A Number</BodyText>
                <Input style={styles.input} 
                blurOnSubmit 
                autoCapitialize='none' 
                autoCorrect={false} 
                keyboardType='number-pad' 
                maxLength={2} 
                value={enteredValue}
                onChangeText={numberStored}
                />
                <View style={styles.buttonContainer}>
                    {/* <View style={styles.button}> */}
                    <View style={{width: buttonWidth}}>
                        <Button title="reset" onPress={() => {resetINputHandler()}} color={colors.accent} />
                    </View>
                 {/* <View style={styles.button}> */}
                 <View style={{width: buttonWidth}}>
                        <Button title="confirm" onPress={() => {confirmTextHanlder()}} color={colors.primary} />
                    </View>
                </View>
            </Card>
            {confirmedOutput}
        </View>
        </TouchableWithoutFeedback>
        </KeyboardAvoidingView>
        </ScrollView>
    );
}

const styles = StyleSheet.create({
    screen: {
        flex: 1,
        padding: 10,
        alignItems: 'center',
    },
    title: {
        fontSize: 20,
        marginVertical: 10,
        // fontFamily: 'open-sans-bold'
        fontFamily: 'OpenSans-Bold'
    },
    inputContainer: {
        // width: 300,
        // maxWidth: '80%',
        // alignItems: 'center',
        //^^ not as flexible 
        width: '80%',
        // maxWidth: '80%',
        maxWidth: '95%',
        minWidth: 300,
        alignItems: 'center',
        //^^^ better for smaller screens
    },
    buttonContainer: {
        flexDirection: 'row',
        width: '100%',
        justifyContent: 'space-between',
        paddingHorizontal: 15
    },
    // button: {
    //     // width: 100
    //     width: Dimensions.get('window').width / 4
    //     //^^ only at first render cycle
    // },
    //^^ using inline objects
    input: {
        width: 100,
        textAlign: 'center',
        height: 50
    },
    summaryContainer: {
        marginTop: 20,
        alignItems: 'center'
    }
});

export default StartGameScreen;