import logo from './logo.svg';
import './App.css';
import Home from "./components/Home/Home";
import AddCustomer from "./components/AddCustomer/AddCustomer";
import CustomerDetail from "./components/CustomerDetail/CustomerDetail";
import { BrowserRouter, Route, Switch } from "react-router-dom";
import Header from './components/common/Header/Header'

function App() {
  return (
    <div>
       <BrowserRouter>
       <Header />
       <Switch>
        <Route path="/" exact component={Home} />
        <Route path="/add" exact component={AddCustomer} />
        <Route path="/:id" exact component={CustomerDetail} />
      </Switch>

      </BrowserRouter>
    </div>
  );
}

export default App;
