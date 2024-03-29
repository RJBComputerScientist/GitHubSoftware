import React from "react";
import { View, Text, StyleSheet, Platform } from 'react-native';

import colors from "../constants/colors";
import TitleText from "./TitleText";

const Header = props => {
    return (
        <View style={{
            ...styles.headerbase, 
            ...Platform.select({
                ios: styles.headerIOS, 
                android: styles.headerAndroid
                    })
                }}>
            <TitleText style={styles.title}>{props.title}</TitleText>
        </View>
    )
}

const styles = StyleSheet.create({
    headerTitle: {
       color: 'black',
       fontSize: 18
    },
    headerbase: {
        width: '100%',
        height: 90,
        paddingTop: 36,
        alignItems: 'center',
        justifyContent: 'center',
        
    },
    headerIOS: {
        backgroundColor: 'white',
        borderBottomColor: '#ccc',
        borderBottomWidth: 1
    },
    headerAndroid: {
        backgroundColor: colors.primary,
        borderBottomColor: 'transparent',
        borderBottomWidth: 0
    },
    title: {
        color: Platform.OS === "ios" ? colors.primary : 'white' 
    },
});

export default Header;