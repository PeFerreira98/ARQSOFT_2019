import React, { Component } from 'react';
import axios from 'axios';

import './MealTable.css';
import Paper from "@material-ui/core/Paper";
import Table from "@material-ui/core/Table";
import TableRow from "@material-ui/core/TableRow";
import TableCell from "@material-ui/core/TableCell";
import TableBody from "@material-ui/core/TableBody";

export class MealTable extends Component{

    constructor(props){
        super(props);
        this.state = {
            meals: [],
            errorText: ''
        }
    }

    fetchMeals = () => {
        axios.get('http://localhost:38867/meal').then((response) => {
            this.setState({
                meals: response.data
            });
        }).catch((serverError) => {
            this.setState({
                errorText: serverError
            });
            console.log(this.state.errorText);
        });
    };

    componentDidMount() {
        this.fetchMeals();
    }

    render() {
        return(
            <div className="MealComponent">
            <Paper className="RootTable">
                <Table aria-label="simple table">
                    <TableRow className="HeaderColumnCell">
                        <TableCell align="center">Meal ID</TableCell>
                        <TableCell align="center">Description</TableCell>
                    </TableRow>
                    <TableBody>
                        {this.state.meals.map(row =>(
                            <TableRow key={row.mealID}>
                                <TableCell align="center" component="th" scope="row">{row.mealID}</TableCell>
                                <TableCell align="center">{row.description}</TableCell>
                            </TableRow>
                        ))}

                    </TableBody>
                </Table>
            </Paper>
            </div>);
    }
}

export default MealTable;