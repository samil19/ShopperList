import React from 'react';
import cardIcon from '../../img/Icon/card.png'
import listIcon from '../../img/Icon/list.png'

class DataDisplayer extends React.Component{
    constructor(props){
        super(props);
        this.state = {"card": true, "properties": []};
this.renderCard = this.renderCard.bind(this);
this.renderTable = this.renderTable.bind(this);
this.changeDisplayer = this.changeDisplayer.bind(this);
this.getProperties = this.getProperties.bind(this);
this.promiseMaker = this.promiseMaker.bind(this);

    }

    componentDidMount(){
        this.getProperties();
    }

    async getProperties(){
        const data = this.props.properties;
        let properties = [];

        data.forEach(property => {
            properties.push(property.dbName);
        });
        await this.promiseMaker({"properties": properties});

        this.callRender();
    }   

    callRender(){
        this.state.card ? this.renderCard() : this.renderTable();
    }

    async changeDisplayer(){ 
await this.promiseMaker({"card": !this.state.card});

        this.callRender();
    }

    promiseMaker(process){
        return new Promise(resolve =>{
            this.setState(() => (process))
            
        return resolve(true);
        
    });
    }

    renderCard(){
        let data = this.props.data;
        let properties = this.state.properties;
        let namePosition = this.props.namePosition;
         let dom = [];
            let bodyCard = [];
            let names = [];
            data.forEach(card => {
                properties.forEach(property =>{
                    bodyCard.push(<span key={card.id + property+ "span"}>
                        <h5 className="card-title" >{property}</h5>
                        <p className="card-text">{card[property]}</p>
                        </span>);
                  });
                  dom.push(<div onClick={() => {this.props.setActive(card)}} className="card text-black bg-light mb-3 me-4 col-3" style={{"maxWidth": 18 + "rem"}} key={card.id + card[properties[namePosition]]}>
                <div className="card-header">{card[properties[namePosition]]}</div>
                <div className="card-body">
                  {bodyCard}
                </div>
              </div>);
              bodyCard = [];
            // Ask someone whyy this work with the strange behavior it has before, before, it shows all the data in all the cards, it should go incresing the data it shows, 
            // but it shows everything since the first card, so it has to be something with JSX or React js rendenring, that maybe it change the variable for the value when it goes
            //  to render
                });
                console.log(names);
            this.setState({"toDisplay": dom});
        

    }

    renderTable(){
        //Ejemplo tabla
         let headNames = [];
         let dom = [];

        
        let data = this.props.data;
        let properties = this.state.properties;
        let namePosition = this.props.namePosition;
        let domNodes = [];
        
        data.forEach(card => {
            
            properties.forEach(property =>{
                if(headNames.length != properties.length){
                    headNames.push(
                        <th className="col" key={property}>{property}</th>
                        );
                }
                domNodes.push(<td key={card.id + card[property]}>
                    {card[property]}
                </td>
                );
              });
              
              dom.push(<tr onClick={() => {this.props.setActive(card)}}>{domNodes}</tr>);
              domNodes = [];
              
            });

             let fatherDom = <div className='card'> <table className='table'><thead><tr>{headNames}</tr></thead><tbody>{dom}</tbody></table></div>


            this.setState({"toDisplay": fatherDom});
    }



render(){
    return(
        <div className="container-fluid">
            <div className="row">
                <div className="d-flex justify-content-end">
                    <button className="btn btn-light me-2" onClick={this.changeDisplayer}>
                    <img src={this.state.card ?  listIcon : cardIcon} alt="" width={18} height={18} />
                    </button>
                    {/* <button className="btn btn-light" onClick={this.changeDisplayer}>
                        <img src={cardIcon} alt="" width={18} height={18} />
                    </button> */}
                    </div>
            </div>
            <div className="mt-3 row">
                        {this.state.toDisplay}
                    </div>
        </div>
    );
}
}

export default DataDisplayer;