import React, {useState} from "react";
import { Pressable, StyleSheet, Dimensions, View } from "react-native";

const HOCButton = (props) => {
    const [counter, setCounter] = useState(0);
    const IncrementCounter = () => {
        setCounter(counter + 1);
        console.log("The Number: "+counter);
    };

    return (
        <>
            <Pressable style={styles.Button} onPressIn={() => {
                props.consoleIn()
                IncrementCounter();
            }} onPressOut={() => {
                // console.log("YOU PRESSED OFF THE BUTTON");
                props.consoleOut()
                // props.NextScreen()
                //^^ would need to use props here
            }}>
                <>
                    {props.children}
                    {/* ^^ NEED THIS IN REACT NATIVE TO INCLUDE CHILDREN */}
                </>
            </Pressable>
        </>
    )
};
const { width, height }  =  Dimensions.get('window');
const styles = StyleSheet.create({
    Button: {
        width: height * 0.15,
        height: height * 0.075,
        backgroundColor: "rgba(34, 34, 34, 0.6)",
        borderRadius: (height * 0.15) / 2
    },
   
});

export default HOCButton;