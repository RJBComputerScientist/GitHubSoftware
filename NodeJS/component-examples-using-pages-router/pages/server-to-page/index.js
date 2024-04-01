import { useState, useEffect, Fragment } from "react";
import Script from "next/script";
import path from 'path';

const BallRoom = () => {
    const pathOfFile = path.join(process.cwd(), 'server.js')
    console.log(pathOfFile)
    const baseStyles = {
        width: '100%',
        height: '100vh',
      }

    return (<Fragment>
        <Script src={pathOfFile} type="module" />
        <div style={{...baseStyles, backgroundColor: 'grey'}}>
         <div > 
         <div style={{backgroundColor: 'white'}}>
            {/* <img src="jxbrowser-logo.svg" class="logo" alt="JxBrowser logo"/> */}
        </div> 
        <h1>Welcome to The BallRoom!</h1>
        <p>Please enter your name and click the button.</p>
        <div className="row">
            <div style={{width: '100%'}}>
            <input style={{color: 'black'}} id="greet-input" placeholder="Your Name"/>
            {"\t".repeat(3)}
            <button id="greet-btn" type="button">Enter Door</button>
            </div>
        </div>
        <p style={{color: 'black'}} id="greet-msg"></p>
         </div> 
         </div>
</Fragment>)
    
};

export default BallRoom;