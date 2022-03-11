import React from 'react';
import { render, fireEvent, act } from '@testing-library/react-native';

import SignIn from '../SignIn';

const FlushMicroTaskQueue = () =>  new Promise((resolve) => setImmediate(resolve));

test("renders default elements", () => { 
    const { getAllByText, getByPlaceholderText } = render(<SignIn />);
    //picking a spot for where the place holder is
    expect(getAllByText("Login").length).toBe(2);
    //^^ length is equal to 2
    getByPlaceholderText("example");
    getByPlaceholderText("***");
    //^^ not detailed
});
//^^ passes by its self

test("shows invalid input messages", () => { 
    const { getByTestId, getByText } = render(<SignIn />);

    fireEvent.press(getByTestId("SignIn.Button"));

    // getByText("Invalid username");
    // getByText("Invalid password");
    //^^ Unable to find an element with text: Invalid username
    //^^^ CANT FIND WHAT WAS PUT IN CODE
    getByText("Invalid username.");
    getByText("Invalid password.");
 });
 //^^^ passes if both inputs test are active

 test("shows invalid user name error message", () => { 
     const { getByTestId, getByText, queryAllByText, debug } = render(<SignIn />);
     //                                              ^^ debug can help with where the outputs happen

     fireEvent.changeText(getByTestId("SignIn.passwordInput"), "asdf");
     // test should fail because the program doesnt have ^^^^ this test ID

     fireEvent.press(getByTestId("SignIn.Button"));

     getByText("Invalid username.");
     expect(queryAllByText("Invalid password.").length).toBe(0);

     fireEvent.changeText(getByTestId("SignIn.usernameInput"), "invalid input");

     getByText("Invalid username.");
     expect(queryAllByText("Invalid password.").length).toBe(0);
     //^^ looking for all of the text

    //  debug();
  });

 test("shows invalid password error message", () => { 
     const { getByTestId, getByText, queryAllByText } = render(<SignIn />);

    //  fireEvent.changeText(getByTestId("SignIn.usernameInput"), "asdf");
     //                                                         ^^^ not password but username should be here
     fireEvent.changeText(getByTestId("SignIn.usernameInput"), "example");

     fireEvent.press(getByTestId("SignIn.Button"));

     getByText("Invalid password.");
     expect(queryAllByText("Invalid username.").length).toBe(0);

     fireEvent.changeText(getByTestId("SignIn.passwordInput"), "invalid input");

     getByText("Invalid password.");
     expect(queryAllByText("Invalid username.").length).toBe(0);
  });

                            /**   CLIENT-SIDE TESTING   **/

  test("handles valid input submission", async () => { 
      fetch.mockResponseOnce(JSON.stringify({ passed: true }));

      const pushMock = jest.fn();
      //^^ allows assertions against the funcitons
      const { getByTestId } = render(<SignIn navigation={{ push: pushMock }} />);

      fireEvent.changeText(getByTestId("SignIn.usernameInput"), "example");
      fireEvent.changeText(getByTestId("SignIn.passwordInput"), "asdf");
      fireEvent.press(getByTestId("SignIn.Button"));

      expect(fetch.mock.calls).toMatchSnapshot();
      await act(FlushMicroTaskQueue);

      expect(pushMock).toBeCalledWith("App");
      //^^ Assertion One this by its self isnt called so i need to await act in order to test properly
      // act - Useful function to help testing components that use hooks API
   });
                /**   SERVER-SIDE TESTING   **/

