import React from "react";

class Filters extends React.Component{

    constructor(props){
        super(props);
    }

    componentDidMount(){
        //La idea es pasarle un json que cargue la estructura de los filtros y se construya dinamicamente
        this.loadFilters()
    }

    loadFilters(){

    }

render(){
    return(
        <div className="col-12">
            Im the filters
        </div>
    );
}

    
}

export default Filters;