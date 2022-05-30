import React from "react";
import axios from "axios";

class Filters extends React.Component{

    constructor(props){
        super(props);
        this.state = {"dom": null, "showFilter": false};
        this.loadFilters = this.loadFilters.bind(this);
        this.toggleFilter = this.toggleFilter.bind(this);
        this.defineCol = this.defineCol.bind(this);
        this.search = this.search.bind(this);
    }

    componentDidMount(){
        //La idea es pasarle un json que cargue la estructura de los filtros y se construya dinamicamente
        this.loadFilters()
    }

    loadFilters(){
        const properties = this.props.properties;
        const toFilter = this.props.toFilter;
        let fields = [];
        let dom;
        toFilter.forEach(index => {
            let fieldAndName = <div key={properties[index]["dbName"]} className={this.defineCol()}> <span className="text-dark">{properties[index]["name"]}</span> {this.fields(properties[index])}</div>
            fields.push(fieldAndName);
        });


        dom = <div className="row">{fields}</div>

        this.setState({"dom": dom})


    }

    defineCol(){
        const toFilter = this.props.toFilter;

        if (toFilter.length != 1 && 12%toFilter.length) {
            return "col-3"            
        }
        return "col-12";

    }

    toggleFilter(){
        this.setState({"showFilter": !this.state.showFilter})
    }
    search(event){
        const value = event.target.value;
        this.props.onSearchHandler(event.target.name +"?"+event.target.name+ "="+value);
        
        event.preventDefault();
    }


    fields(property){
        switch (property.type) {
            case "input":
                return <input className="form-control" name={property.name} placeholder={property.placeholder} onChange={this.search} />
                break;
        
            default:
                break;
        }
    }



render(){
    return(
        <div className="container-fluid mb-3">
            <div className="card">
                <div className="card-header">
                    <h4 className="text-dark" onClick={this.toggleFilter}>Filters</h4></div>
                <div className="card-body row" style={{"display": this.state.showFilter ? "block":"none"}}>
                {this.state.dom}
                </div>
            </div>
        </div>
    );
}

    
}

export default Filters;