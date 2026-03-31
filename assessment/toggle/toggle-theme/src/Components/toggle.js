import React,{useState} from "react";
import './toggle.css';

function Toggle(){
    const[darkMode, setDarkMode] = useState(true);

    const toggleTheme = () =>{
        setDarkMode(!darkMode);
    }



return(
  <div className={darkMode ? ' container dark' : 'container light'}>
    <h1>Light/Dark toggle Mode</h1>
    <h2> Mode: {darkMode ? 'Dark' : 'Light'}</h2>
    <button onClick={toggleTheme} >
        Toggle Theme
    </button>
  </div>
);
}

export default Toggle;