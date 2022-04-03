import React from "react";
import axios from "axios";
import DataShower from "../Components/DataShower";

class RawProduct extends React.Component{
    constructor(props){
        super(props);
        this.state = {"data": []}
        this.getData = this.getData.bind(this);
    }
    componentDidMount(){
    this.getData();
        
    }

getData(){
    axios.get("https://localhost:44376/RawProduct").then(request =>{
        let elements = [];
        if(request){
            request.data.forEach(ele => {
                elements.push(<div key={ele.id} className="card col-3 text-dark m-2">{JSON.stringify(ele)}</div>);
            });
        }    
        this.setState({"data": elements});    
        
        console.log(request.data);
        });
}

    render(){
        return(
            <div>
                <DataShower />
                {/* <div className="row m-4">
                    {this.state.data}
                </div> */}
            
            </div>);
    }
}

export default RawProduct;