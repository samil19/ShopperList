import React from "react";
import axios from "axios";
import Filters from '../../Components/Filters';
import DataDisplayer from "../../Components/DataDisplayer/DataDisplayer";
import model from "../../FilterConfiguration/Products.json"
import DetailDisplayer from "../../Components/DetailDisplayer/DetailDisplayer"
import EditComponent from "../../Components/EditComponent/EditComponent"

class RawProduct extends React.Component{
    constructor(props){
        super(props);
        this.state = {"data": [], "properties": model, "activeItem" : {}, "mode": "list"}
        this.getData = this.getData.bind(this);
        this.promiseMaker = this.promiseMaker.bind(this);
        this.getDataFiltered = this.getDataFiltered.bind(this);
        this.setActiveItem = this.setActiveItem.bind(this);
        this.cleanActiveItem = this.cleanActiveItem.bind(this);
        this.setEditMode = this.setEditMode.bind(this);
        this.cancelChanges = this.cancelChanges.bind(this);
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

getDataFiltered(value){
    if(value)
    this.getData("https://localhost:44376/RawProduct/" + value);
    else
    this.getData();
}
getData(url = "https://localhost:44376/RawProduct"){
    axios.get(url).then(async request =>{
        if(request){
            this.setState({"data": []});

            this.setState({"data": request.data});
        };
         
        });
}

setActiveItem(e){
    this.setState({"activeItem": e})
}

cleanActiveItem(){
    this.setState({"activeItem": {}});
}

setEditMode(){
    this.setState({"mode": "edit"});
}
cancelChanges(){
this.setState({"mode":"list"})
}


    render(){
        return(
            <div>
                { JSON.stringify(this.state.activeItem) == "{}" ? 
                <div>

                {this.state.properties.length ? <Filters properties={this.state.properties} toFilter={[1]} onSearchHandler={this.getDataFiltered} /> : "No Filter"}
                
                {this.state.data.length ? <DataDisplayer data={this.state.data} properties={this.state.properties} namePosition={2} setActive={this.setActiveItem} /> : "No Data"}
                
                </div> :
                <div>
                    {this.state.mode ==="list" ? <DetailDisplayer activeItem={this.state.activeItem} properties={this.state.properties} namePosition={2} cleanActive={this.cleanActiveItem} editMode={this.setEditMode}/> 
                :    
                <EditComponent activeItem={this.state.activeItem} properties={this.state.properties} namePosition={2} cancelEdit={this.cancelChanges}/>
                } 
                </div>
    }
            
            </div>);
    }
}

export default RawProduct;