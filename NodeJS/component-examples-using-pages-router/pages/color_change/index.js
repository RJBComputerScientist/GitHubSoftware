import { useEffect, useState } from "react";


export default function readDOM() {
    const LIGHT_COLOR = '#dfdfdf'
    const DARK_COLOR = '#424241'

    // using light color by default
    const [backgroundColor, setBackgroundColor] = useState(LIGHT_COLOR)
    useEffect(() => {
        const COLOR_CHANGE_BREAKPOINT_IN_PX = 800;
        const Resize = () => {
            if(window.innerWidth > COLOR_CHANGE_BREAKPOINT_IN_PX){
                setBackgroundColor(LIGHT_COLOR);
            } else {
                setBackgroundColor(DARK_COLOR);
            }
        }
        addEventListener('resize', Resize)
        console.log(window);
    },[])
    const baseStyles = {
        width: '100%',
        height: '100vh',
      }
    return(
            <div style={{...baseStyles, backgroundColor}}>
            <h1 style={{color: !backgroundColor, fontSize: '36px'}}>Reading DOM Page</h1>
            </div>
    )
}