import React, { Component } from 'react';
import axios from 'axios';

import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TablePagination from '@material-ui/core/TablePagination';
import TableRow from '@material-ui/core/TableRow';
import Paper from '@material-ui/core/Paper';

import './MealItemTable.css';


export class MealItemTable extends Component {

    constructor(props) {
        super(props);
        this.state = {
            meals: [],
            mealItens: [],
            expirationDate: [],
            errorText: ''
        }
    }

    fetchMeals = () => {
        axios.get('https://gorgeousfoodapi.azurewebsites.net/api/meal').then((response) => {
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

    fetchMealItens = () => {
        axios.get('https://gorgeousfoodapi.azurewebsites.net/api/mealitem').then((response) => {
            console.log(response);
            this.setState({
                mealItens: response.data
            });
        }).catch((serverError) => {
            this.setState({
                errorText: serverError
            });
            console.log(this.state.errorText);
        });
    };

    componentDidMount() {
        this.fetchMealItens();
    }


    render() {

        return(
            <div className="ItemMealComponent">
                <Paper className="RootTable">
                <Table aria-label="simple table">
                    <TableRow className="HeaderColumnCell">
                        <TableCell align="center">Meal Item ID</TableCell>
                        <TableCell align="center">Production Date</TableCell>
                        <TableCell align="center">Expiration Date</TableCell>
                        <TableCell align="center">Meal ID</TableCell>
                        <TableCell align="center">Meal Description</TableCell>
                    </TableRow>
                    <TableBody>
                        {this.state.mealItens.map(row => (
                            <TableRow key={row.mealItemID}>
                                <TableCell align="center" component="th" scope="row">{row.mealItemID}</TableCell>
                                <TableCell align="center">{row.productionDate}</TableCell>
                                <TableCell align="center">{row.expirationDate}</TableCell>
                                <TableCell align="center">{row.mealID}</TableCell>
                                <TableCell align="center">{row.meal.description}</TableCell>
                            </TableRow>
                        ))}
                    </TableBody>
                </Table>
                </Paper>
            </div>
        );
    }
}

export default MealItemTable;