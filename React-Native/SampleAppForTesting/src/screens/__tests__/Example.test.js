import React from 'react';
import { render, fireEvent, act } from '@testing-library/react-native';

import Example from '../Example';

test('HOC Buttons', () => { 
    const { getByTestId } = render(<Example />);

    fireEvent.press(getByTestId("SignIn.HOCBUtton2"));
 })