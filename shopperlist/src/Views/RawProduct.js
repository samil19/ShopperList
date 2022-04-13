import React from "react";
import axios from "axios";
import Filters from '../Components/Filters';
import DataShower from "../Components/DataShower/DataShower";
import model from "../FilterConfiguration/Products.json"

class RawProduct extends React.Component{
    constructor(props){
        super(props);
        this.state = {"data": [], "properties": []}
        this.getData = this.getData.bind(this);
        this.promiseMaker = this.promiseMaker.bind(this);
    }
    componentDidMount(){
    this.getData();
        
    }
    promiseMaker(process){
        return new Promise(resolve =>{
            this.setState(() => (process))
            
        return resolve(true);
        
    });
    }

getData(){
    axios.get("https://localhost:44376/RawProduct").then(async request =>{
        let elements = [];
        if(request){
            request.data.forEach(ele => {
                elements.push(<div key={ele.id} className="card col-3 text-dark m-2">{JSON.stringify(ele)}</div>);
            });
        };
        
        this.setState({"data": request.data, "properties": model}); 
        });
}

    render(){
        return(
            <div>
                {this.state.properties.length ? <Filters properties={this.state.properties} toFilter={[1]} /> : "No Filter"}
                
                {this.state.data.length ? <DataShower data={this.state.data} properties={this.state.properties} namePosition={1}/> : "No Data"}
                
                {/* <div className="row m-4">
                    {this.state.data}
                </div> */}
            
            </div>);
    }
}

export default RawProduct;