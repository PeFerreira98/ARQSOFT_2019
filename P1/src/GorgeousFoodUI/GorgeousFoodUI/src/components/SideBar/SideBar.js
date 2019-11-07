import React, { Component } from 'react';
import './SideBar.css';
import MealItemTable from "../MealItemTable/MealItemTable";
import InventoryTable from "../IventoryTable/InventoryTable";
import MealTable from "../Meal/MealTable";

export class SideBar extends Component {

    constructor(props){
        super(props);
        this.state = {
            selectedInvetories: false,
            selectedMealItens: false,
            selectedMeals: false
        };

        this.handleInvetoriesOption = this.handleInvetoriesOption.bind(this);
        this.handleMealItensOption = this.handleMealItensOption.bind(this);
        this.handleMealsOption = this.handleMealsOption.bind(this);
    }

    handleInvetoriesOption(){
        this.setState(
            {selectedInvetories: true,
                selectedMealItens: false,
                selectedMeals: false})
    }

    handleMealItensOption(){
        this.setState(
            {selectedInvetories: false,
                selectedMealItens: true,
                selectedMeals: false})
    }

    handleMealsOption(){
        this.setState(
            {selectedInvetories: false,
                selectedMealItens: false,
                selectedMeals: true
            }
        )
    }

    render() {
        let menu = null;
        /*if(this.state.selectedInvetories){
            menu = <InventoryTable/>
        }*/
        if(this.state.selectedMealItens){
            menu = <MealItemTable/>
        }

        if(this.state.selectedMeals){
            menu = <MealTable/>
        }

        return(
            <div className="LeftBox">
                <div className="SideBar">
                    {/*<li className={this.state.selectedInvetories ? "ButtonBoxActive" : "ButtonBox"}
                        onClick={this.handleInvetoriesOption}>
                        <div className="TextOptions">Inventories</div>
                    </li>*/}

                    <li className={this.state.selectedMealItens ? "ButtonBoxActive" : "ButtonBox"}
                        onClick={this.handleMealItensOption}>
                        <div className="TextOptions">Meal Itens</div>
                    </li>

                    <li className={this.state.selectedMeals ? "ButtonBoxActive" : "ButtonBox"}
                        onClick={this.handleMealsOption}>
                        <div className="TextOptions">Meals</div>
                    </li>
                </div>
                {menu}
            </div>
        );
    }
}

export default SideBar;