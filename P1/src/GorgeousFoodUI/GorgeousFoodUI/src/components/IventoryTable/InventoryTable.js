import React, { Component } from 'react';
import Paper from "@material-ui/core/Paper";
import Table from "@material-ui/core/Table";
import TableRow from "@material-ui/core/TableRow";
import TableCell from "@material-ui/core/TableCell";
import TableBody from "@material-ui/core/TableBody";
import './InventoryTable.css'

export class InventoryTable extends Component{
    render() {
        return(
            <div className="InventoryComponent">
                <Paper className="RootTable">
                    <Table className="MealItensTable" aria-label="simple table">
                        <TableRow className="HeaderColumnCell">
                            <TableCell align="center">Inventory ID</TableCell>
                            <TableCell align="center">Date</TableCell>
                        </TableRow>
                        <TableBody>

                        </TableBody>
                    </Table>
                </Paper>
            </div>
        );
    }
}

export default InventoryTable;