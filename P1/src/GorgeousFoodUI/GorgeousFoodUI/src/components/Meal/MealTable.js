import React, { Component } from 'react';
import axios from 'axios';

import './MealTable.css';
import Paper from "@material-ui/core/Paper";
import Table from "@material-ui/core/Table";
import TableRow from "@material-ui/core/TableRow";
import TableCell from "@material-ui/core/TableCell";
import TableBody from "@material-ui/core/TableBody";

export class MealTable extends Component{
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

                    </TableBody>
                </Table>
            </Paper>
            </div>);
    }
}

export default MealTable;