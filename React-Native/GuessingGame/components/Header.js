import React from "react";
import { View, Text, StyleSheet } from 'react-native';

import colors from "../constants/colors";
import TitleText from "./TitleText";

const Header = props => {
    return (
        <View style={styles.Header}>
            <TitleText >{props.title}</TitleText>
        </View>
    )
}

const styles = StyleSheet.create({
    headerTitle: {
       color: 'black',
       fontSize: 18
    },
    Header: {
        width: '100%',
        height: 90,
        paddingTop: 36,
        backgroundColor: colors.primary,
        alignItems: 'center',
        justifyContent: 'center'
    },
});

export default Header;