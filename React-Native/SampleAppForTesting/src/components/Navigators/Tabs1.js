import { createBottomTabNavigator } from "@react-navigation/bottom-tabs";
import { createStackNavigator } from "@react-navigation/stack";
import Example from "../../screens/Example";
import Customized from "../../screens/Customized";
import SignIn from "../../screens/SignIn";
import { Dimensions, StyleSheet, Text, View, Image, TouchableOpacity } from "react-native";

const Tab = createBottomTabNavigator();
const Stack = createStackNavigator();
const { height } = Dimensions.get('screen');
const CustomTabBarButton = ({children, onPress}) => {
    return (
    <TouchableOpacity onPress={onPress} style={{
        top: -30,
        justifyContent: 'center',
        alignItems: 'center',
        ...styles.shadow
    }}>
        <View style={{
            width: height * 0.09,
            height: height * 0.09,
            borderRadius: (height * 0.09) / 2,
            backgroundColor: '#e32f45'
        }}>
            {children}
        </View>
    </TouchableOpacity>
    )
}
const Tabs1 = () => {
    return (
        <Tab.Navigator 
            screenOptions={{
                tabBarShowLabel: false,
                tabBarStyle: {
                    position: 'absolute',
                    bottom: 25,
                    left: 20,
                    right: 20,
                    elevation: 0,
                    backgroundColor: "#f5f5f5",
                    borderRadius: 15,
                    height: height * 0.08,
                    ...styles.shadow
                }
            }}
        >
            {/* <Tab.Screen name="SignIn" component={SignIn} options={{
                tabBarIcon: ({focused}) => {
                    return(
                    <View style={{ alignItems: 'center', justifyContent: 'center', top: 10 }}>
                        <Image source={require('../../../assets/icons/icons8-home-100.png')} 
                            resizeMode={'contain'}
                            style={{ 
                                width: 25,
                                height: 25,
                                tintColor: focused ? '#e32f45' : '#748c94'
                            }}
                        />
                        <Text style={{ color: focused ? '#e32f45' : '#748c94', fontSize: 12 }}>App</Text>
                    </View>
                    )
                },
            }} /> */}
            <Tab.Screen name="App" component={Example} options={{
                tabBarIcon: ({focused}) => {
                    return(
                    <Image source={require('../../../assets/icons/plus.png')}
                    resizeMode={'contain'}
                    style={{
                        width: 30, 
                        height: 30,
                        tintColor: '#fff'
                    }}
                    />
                    )
                },
                tabBarButton: (props) => {
                    return (
                        <CustomTabBarButton {...props} />
                    )
                }
            }} />
            <Tab.Screen name="Customized" component={Customized} options={{
                  tabBarIcon: ({focused}) => {
                      return(
                    <View style={{ alignItems: 'center', justifyContent: 'center', top: 10 }}>
                        <Image source={require('../../../assets/icons/icons8-react-native-100.png')} 
                            resizeMode={'contain'}
                            style={{ 
                                width: 25,
                                height: 25,
                                tintColor: focused ? '#e32f45' : '#748c94'
                            }}
                        />
                        <Text style={{ color: focused ? '#e32f45' : '#748c94', fontSize: 12 }}>Customized</Text>
                    </View>
                      )
                },
            }} />
        </Tab.Navigator>
    )
};

const Stack1 = () => {
    return (
<Stack.Navigator>
      <Stack.Screen
        name="SignIn"
        component={SignIn}
        options={{ title: "Sign In" }}
      />
        <Stack.Screen
          name="Tabs1"
          component={Tabs1}
          options={{ title: "Tabs One" }}
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
    </Stack.Navigator>
    )
};

const styles = StyleSheet.create({
    shadow: {
        shadowColor: '#7F5DF0',
        shadowOffset: {
            width: 0,
            height: 10
        },
        shadowOpacity: 0.25,
        shadowRadius: 3.5,
        elevation: 5
    },
});

// export default Tabs1;
export default Stack1;