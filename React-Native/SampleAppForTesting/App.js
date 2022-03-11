import React from "react";

import { NavigationContainer } from "@react-navigation/native";
// import { createStackNavigator } from "@react-navigation/stack";

import SignIn from "./src/screens/SignIn";
import Example from "./src/screens/Example";
import Customized  from './src/screens/Customized';
// import Tabs1 from "./src/components/Navigators/Tabs1";
import Stack1 from "./src/components/Navigators/Tabs1";

// const Stack = createStackNavigator();

export default () => (
  
  // <NavigationContainer>
  //   <Stack.Navigator>
  //     <Stack.Screen
  //       name="SignIn"
  //       component={SignIn}
  //       options={{ title: "Sign In" }}
  //     />
  //     <Stack.Screen
  //       name="App"
  //       component={Example}
  //       options={{ title: "Success!" }}
  //     />
  //     <Stack.Screen
  //       name="Customized"
  //       component={Customized}
  //       options={{ title: "Customized!" }}
  //     />
  //   </Stack.Navigator>
  //   {/* CANT HAVE YOUR NAVIGATOR LIKE THIS */}
  //     <Tabs1 />
  // </NavigationContainer>
    // {/* ^^^^^ CANT HAVE YOUR NAVIGATOR LIKE THIS */}
  <NavigationContainer>
    {/* <Stack.Navigator>
      <Stack.Screen
        name="SignIn"
        component={SignIn}
        options={{ title: "Sign In" }}
      />
      <Stack.Screen
        name="App"
        component={Example}
        options={{ title: "Success!" }}
      />
      <Stack.Screen
        name="Customized"
        component={Customized}
        options={{ title: "Customized!" }}
      />
    </Stack.Navigator> */}
    {/* CANT HAVE YOUR NAVIGATOR LIKE THIS */}
    {/* <Tabs1 /> */}
    <Stack1 />
  </NavigationContainer>
);