import React from "react";
import { View, Pressable, StyleSheet, Dimensions, Text } from 'react-native';
import HOCButton from "../components/HOCButton";

const Customized = () => {
    return (
        <>
        <View style={styles.TopContainer}>
            <Text>The Customized Screen</Text>
        </View>
        <View style={styles.BottomContainer}>
            <Pressable>
                <Text>HOC Button</Text>
            </Pressable>
        </View>
        </>
    )
};

const styles = StyleSheet.create({
    TopContainer: {
        flex: 0.5,
        justifyContent: 'center',
        alignItems: 'center',
    },
    BottomContainer: {
        flex: 0.5,
        justifyContent: 'center',
        alignItems: 'center',
    },
})

export default Customized;