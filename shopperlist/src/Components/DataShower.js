import React from 'react';
import Filters from './Filters';
import cardIcon from '../img/Icon/card.png'
import listIcon from '../img/Icon/list.png'

class DataShower extends React.Component{
    constructor(props){
        super(props);
        this.state = {"card": true};
this.renderCard = this.renderCard.bind(this);
this.renderTable = this.renderTable.bind(this);

    }

    



    renderCard(){
        let data = this.props.data;
        if(data != undefined){
            data.forEach(element => {
                this.setState({"toDisplay": <div className="card text-white bg-secondary mb-3" style="max-width: 18rem;">
                <div className="card-header">Header</div>
                <div className="card-body">
                  <h5 className="card-title">Secondary card title</h5>
                  <p className="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                </div>
              </div>}) 
            });
        }

    }

    renderTable(){

    }



render(){
    return(
        <div className="container-fluid">
            <div className="row">
                <Filters />
                <div class="d-flex justify-content-end">
                    <button className="btn btn-light me-2">
                    <img src={listIcon} alt="" width={18} height={18} />
                    </button>
                    <button className="btn btn-light">
                        <img src={cardIcon} alt="" width={18} height={18} />
                    </button>
                    </div>
                    <div className="row">
                        {this.state.toDisplay}
                    </div>
            </div>
        </div>
    );
}
}

export default DataShower;