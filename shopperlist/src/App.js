
import './App.css';
import {  BrowserRouter as Router,  Routes,  Route} from "react-router-dom";
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap/dist/js/bootstrap.min.js';
import React from 'react';
import cart from "./img/grocery-cart.png";


//Views
import  Home  from "./Views/Home";
import  RawProduct  from "./Views/RawProduct/RawProduct";


class App extends React.Component{
  constructor(props){
    super(props);
    this.state = {"actualView": <h1>{"Section Name"}</h1>}
    this.changeView = this.changeView.bind(this);
  }

  
  componentDidMount() {
    // this.viewChange();
  }
changeView(e) {
  let element;
  if(e != "Home"){
    element = <h1>{e}</h1>;
    //  this.setState({"actualView": e})
  }
}

render(){
  return (
    <div id='App' className="container-fluid">
      <nav className="navbar navbar-expand-lg navbar-light bg-light">
  <div className="container-fluid">
    <a className="navbar-brand" href="/"><img src={cart} alt="" width="30" height="24" className="d-inline-block align-text-top" />
       Shopper List</a>
    <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
      <span className="navbar-toggler-icon"></span>
    </button>
    <div className="collapse navbar-collapse" id="navbarNav">
      <ul className="navbar-nav">
        <li className="nav-item">
          <a className="nav-link active" aria-current="page" href="/Products">Products</a>
        </li>
        <li className="nav-item">
          <a className="nav-link" href="/Brands">Brands</a>
        </li>
        <li className="nav-item">
          <a className="nav-link" href="/Categories">Categories</a>
        </li>
        <li className="nav-item">
          <a className="nav-link disabled" href="#" aria-disabled="true">Disabled</a>
        </li>
      </ul>
    </div>
  </div>
</nav>
<div id="content" className="row">
  {this.state.actualView}
<Router>
<Routes>
  
    <Route path='/' element={<Home/>}>
    </Route>
    <Route path='/Products' element={<RawProduct/>}>
      </Route>
  </Routes>
  </Router>


  
</div>
    </div>
  );
};
}

export default App;
