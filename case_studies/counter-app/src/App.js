import logo from './logo.svg';
import './App.css';
import Counter from './Components/Counter';
import StateVsPropsDemo from './Components/stateVsProdDemo';
import TemperatureConverter from './Components/TemperatureConverter';

function App() {
  return (
    <div className="App">
      <TemperatureConverter />
    </div>
  );
}

export default App;
