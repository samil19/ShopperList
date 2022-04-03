import React from "react";
import cart from "../img/grocery-cart.png"

class Home extends React.Component{
    constructor(props){
        super(props);
    }




    render(){
        return(
            <div>
                <div className="text-center">
                    <h1 className="beautyLetter mt-3">Shopper List</h1>
                <img src={cart} className="img-fluid"  alt="" />
                </div>

            </div>
        );
    }

}

export default Home;