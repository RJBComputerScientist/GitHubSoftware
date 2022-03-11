import { Text, StyleSheet, View } from 'react-native';
import HOCButton from '../components/HOCButton';
const styles = StyleSheet.create({
    container: {
        flex: 1,
        justifyContent: 'space-around',
        alignItems: 'center',
        padding: 50,
    },
        TextCentering: {
            justifyContent: 'center',
            alignItems: 'center',
            textAlign: 'center',
        },
});

const ScreenNames = ["Customized"];

const ToNextScreen = (NextScreen,{navigation}) => {
    navigation.push(NextScreen);
};

// const Example = ({navigation}) => {

// }

export default ({ navigation }) => {
    return (
        <View style={styles.container}>
            <HOCButton
            consoleIn={()=>console.log("OnPressIn Button 1")}
            consoleOut={()=>{
                console.log("OnPressOut Button 1")
                ToNextScreen(ScreenNames[0], {navigation})
                }}>
                <Text style={styles.TextCentering}>{ScreenNames[0]}</Text>
            </HOCButton>
            <HOCButton consoleIn={()=>console.log("OnPressIn Button 2")} consoleOut={()=>console.log("OnPressOut Button 2")} />
            <HOCButton consoleIn={()=>console.log("OnPressIn Button 3")} consoleOut={()=>console.log("OnPressOut Button 3")} />
        </View>
    )
};
// export default () => null;
//^^ needed a component to reference fo testing .. now im creating my way to the third screen