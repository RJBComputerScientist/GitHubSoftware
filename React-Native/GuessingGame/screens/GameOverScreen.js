import React from "react";
import { View, Text, StyleSheet, Button, Image } from 'react-native';
import BodyText from "../components/BodyText";
import TitleText from "../components/TitleText";
import colors from '../constants/colors';
import MainButton from "../components/MainButton";

const GameOverScreen = props => {
   return( 
   <View style={styles.screen}>
        <TitleText>The Game Is Over!</TitleText>
        <View style={styles.imageContainer}>
        <Image 
        source={require('../assets/Images/success.png')} 
        // source={{uri: 'https://cdn.pixabay.com/photo/2016/05/05/23/52/mountain-summit-1375015_1280.jpg'}} 
        style={styles.image}
        resizeMode="cover"
        fadeDuration={1000}
        />
        </View>
        <View style={styles.resultContainer}>
            <BodyText style={styles.resultText}>Your Phone Needed <Text style={styles.highlight}>{props.roundsNumber}</Text> Rounds To Guess The 
            Number <Text style={styles.highlight}>{props.userNumber}</Text>.</BodyText>
        </View>
        <MainButton onPress={props.onRestart} >
            NEW GAME
        </MainButton>
    </View>
   )
};

const styles = StyleSheet.create({
    screen: {
        flex: 1,
        justifyContent: 'center',
        alignItems: 'center'
    },
    image: {
        width: '100%',
        height: '100%',
    },
    imageContainer: {
        borderRadius: 150,
        borderWidth: 3,
        borderColor: 'black',
        width: 300,
        height: 300,
        overflow: 'hidden',
        marginVertical: 20
    },
    highlight: {
        color: colors.primary,
        fontFamily: 'OpenSans-Bold'
    },
    resultContainer: {
        marginHorizontal: 30,
        marginVertical: 15
    },
    resultText: {
        textAlign: 'center',
        fontSize: 20
    },
});

export default GameOverScreen;