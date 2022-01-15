import React from "react";
import {
    View, 
    TouchableOpacity, 
    //^^ for ios .. still need to check for touchableOpacity for "ButtonComponent"
    StyleSheet,
    Text, 
    TouchableNativeFeedback,
    //^^ android
    Platform
} from 'react-native';
import colors from "../constants/colors";

const MainButton = props => {
    let ButtonComponent = TouchableOpacity;
    //^^ only First letter capital can be used as jsx objects

    if(Platform.Version >= 21){
        //                   ^^^^ android api verion 21 or higher supports ripple effect
        ButtonComponent = TouchableNativeFeedback;
    }
    return(
        <View style={styles.buttonContainer}>
        <ButtonComponent activeOpacity={0.7} onPress={props.onPress}>
            <View style={styles.button}>
                <Text style={styles.buttonText}>{props.children}</Text>
            </View>
        </ButtonComponent>
        </View>
    );
};

const styles = StyleSheet.create({
    button: {
        backgroundColor: colors.primary,
        paddingVertical: 12,
        paddingHorizontal: 30,
        borderRadius: 25 
    },
    buttonText: {
        fontFamily: 'OpenSans-Regular',
        color: 'white',
        fontSize: 18
    },
    buttonContainer: {
        borderRadius: 25,
        overflow: "hidden"
    },
});

export default MainButton;