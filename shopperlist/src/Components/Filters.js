import React from "react";

class Filters extends React.Component{

    constructor(props){
        super(props);
        this.state = {"dom": null};
        this.loadFilters = this.loadFilters.bind(this);
    }

    componentDidMount(){
        //La idea es pasarle un json que cargue la estructura de los filtros y se construya dinamicamente
        this.loadFilters()
    }

    loadFilters(){
        let fields = [];
        let properties = this.props.properties;
        let toFilter = this.props.toFilter;
        let dom;
        toFilter.forEach(index => {
            fields.push(this.fields(properties[index]));
        });


        dom = <div className="row">{fields}</div>

        this.setState({"dom": dom})


    }


    fields(property){
        switch (property.type) {
            case "input":
                return <input className="form-control" key={property.dbName} name={property.name} placeholder={property.placeholder}  />
                break;
        
            default:
                break;
        }
    }



render(){
    return(
        <div className="col-12">
            Im the filters
            {this.state.dom}
        </div>
    );
}

    
}

export default Filters;