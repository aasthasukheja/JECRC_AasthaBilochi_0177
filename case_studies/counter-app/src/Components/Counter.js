import React,{useState} from "react";

function Counter(){
    const[count, setCount] = useState(0);
    const [step, setStep] = useState(1);
    const [lastAction, setLastAction] = useState("None");



    const increment = () =>{
        setCount(count + step);
        setLastAction("Incremented by " + step );
        }

    const decrement = () =>{
        setCount(count - step);
        setLastAction("Decremented by " + step );
    }
    const reset = () =>{
        setCount(0);
        setLastAction("Reset to 0");
    }   

    return(
        <div style ={{padding: "20px", textAlign: "center" }}>
        <div style = {{fontSize: "48px",margin: "20px "}}>
            <h1>Counter App</h1> 
            </div>
        <div style = {{fontSize: "36px", margin: "20px"}}>
            <label>Step: </label>
            <input 
            type="number"
            value={step}
            onChange={(e) => setStep(Number(e.target.value))}
            />
        </div>
        <div style = {{fontSize: "36px", margin: "20px"}}>
            <h2>Count: {count}</h2>
        </div>
        <div style = {{fontSize: "36px", margin: "20px"}}>
            <button onClick={increment}>Increment</button>
            <button onClick={decrement}>Decrement</button>
            <button onClick={reset} style={buttonStyle}>Reset</button>  
            <br />
            <p>Last Action: {lastAction}</p>
        </div>
        </div>
    );
}

const buttonStyle = {
    margin: "0 10px",
    padding: "10px 20px",   
    fontSize: "16px",
    cursor: "pointer",
    backgroundColor: "#007BFF", 
    color: "#fff",
    border: "none",
    borderRadius: "5px",    
};
export default Counter;