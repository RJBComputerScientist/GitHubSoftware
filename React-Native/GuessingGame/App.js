/**
 * Sample React Native App
 * https://github.com/facebook/react-native
 *
 * @format
 * @flow strict-local
 */

import React, {useState} from 'react';
import {
  SafeAreaView,
  StyleSheet,
  ScrollView,
  View,
  Text,
  StatusBar,
} from 'react-native';
import Header from './components/Header';
import StartGameScreen from './screens/StartGameScreen';
import GameScreen from './screens/GameScreen';
import GameOverScreen from './screens/GameOverScreen';
// import * as Font from 'expo-font';
// import AppLoading from 'expo-app-loading';

// const fetchFonts = () => {
//   return Font.loadAsync({
//     'open-sans': require('./Fonts/OpenSans-Regular.ttf'),
//     'open-sans-bold': require('./Fonts/OpenSans-Bold.ttf'),
//   });
// }

export default function App(){
  const [userNumber, setUserNumber] = useState();
  const [guessRounds, setGuessRounds] = useState(0);
  // const [dataLoaded, setDataLoaded] = useState(false);

  // if(!dataLoaded){
  //   return <AppLoading 
  //         startAsync={fetchFonts}
  //         onFinish={() => setDataLoaded(true)}
  //         onError={(err) => console.log(err)}
  //      />
  // }

  const ConfigureNewGameHandler = () => {
    setGuessRounds(0);
    setUserNumber(null);
  }

  const StartGameHandler = (SelectedNumber) => {
    setUserNumber(SelectedNumber);
    setGuessRounds(0);
  };

  const gameOverHandler = numOfRounds => {
    setGuessRounds(numOfRounds)
  }

  let content = <StartGameScreen onStartGame={StartGameHandler} />;
  // content = <GameOverScreen roundsNumber={1} userNumber={1  } onRestart={ConfigureNewGameHandler} />
  // ^^^ for testing
  if(userNumber && guessRounds <= 0){ 
    content = <GameScreen userChoice={userNumber} onGameOver={gameOverHandler} />;
  } else if(guessRounds > 0){
    content = <GameOverScreen roundsNumber={guessRounds} userNumber={userNumber} onRestart={ConfigureNewGameHandler} />
  }
  return (
    <SafeAreaView style={styles.screen}>
      <Header title="Guess A Number" />
      {content}
    </SafeAreaView>
  );
}

const styles = StyleSheet.create({
  screen: {
    flex: 1
  },
});

