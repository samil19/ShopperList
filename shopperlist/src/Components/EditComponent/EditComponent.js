import React from "react";

class EditComponent extends React.Component{
    constructor(props){
        super(props);
        this.state = {};
        this.renderData = this.renderData.bind(this);
    }
componentDidMount(){
this.renderData();
}

renderData(){
    let data = this.props.activeItem;
        let properties = this.props.properties;
        let namePosition = this.props.namePosition;
         let dom = [];
            let bodyCard = [];
            let names = [];
            let image;
                properties.forEach(property =>{
                    if(property["type"] != "image")
                    bodyCard.push(<span key={data.id + property["dbName"]+ "span"} className=" col-sm-12 col-lg-6 col-xl-3 col-xxl-2">
                    <h5 className="card-title" >{property["name"]}</h5>
                    <p className="card-text mb-4">{data[property["dbName"]]}</p>
                    </span>
                    );
                        else
                        image = <img key={data.id + property["dbName"]+ "img"} src={property["placeholder"]} className="img-fluid mb-3" />;
                  });
                  dom.push(<div className="card text-center text-dark bg-light mb-3 me-4" key={data.id + data[properties[namePosition]]}>
                <div className="card-header">{data[properties[namePosition]["dbName"]]}</div>
                <div className="card-body">
                    {image}
                    <div className="row">
                  {bodyCard}
                    </div>
                </div>
              </div>);
              bodyCard = [];
            // Ask someone whyy this work with the strange behavior it has before, before, it shows all the data in all the cards, it should go incresing the data it shows, 
            // but it shows everything since the first card, so it has to be something with JSX or React js rendenring, that maybe it change the variable for the value when it goes
            //  to render
                console.log(names);
            this.setState({"toDisplay": dom});
}

    render(){
        return(
            <div className="container-fluid">
            <h1>Soy el editoor</h1>
            <div className="mt-3 row">
                        {this.state.toDisplay}
                    </div>
                    <div className="row">
                        <div className="d-flex justify-content-end">
                             <button className="btn btn-outline-light me-3" onClick={this.props.cancelEdit}>Cancel</button>
                             <button className="btn btn-outline-danger">Delete</button>
                            {/* Aqui van los botones de salir, editar y mas */}
                        </div>
                    </div>
        </div>
    //     <div class="card text-center text-dark">
    //     <div class="card-header">
    //       Featured
    //     </div>
    //     <div class="card-body">
    //       <h5 class="card-title">Special title treatment</h5>
    //       <p class="card-text">With supporting text below as a natural lead-in to additional content.</p>
    //       <a href="#" class="btn btn-primary">Go somewhere</a>
    //     </div>
    //     <div class="card-footer text-muted">
    //       2 days ago
    //     </div>
    //   </div>
      )
    }
    
}

export default EditComponent;