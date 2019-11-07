import React, { Component } from 'react';
import { forwardRef } from 'react';
import './MealItemTable.css'
import axios from 'axios';
import MaterialTable from 'material-table';
import AddBox from '@material-ui/icons/AddBox';
import ArrowUpward from '@material-ui/icons/ArrowUpward';
import Check from '@material-ui/icons/Check';
import ChevronLeft from '@material-ui/icons/ChevronLeft';
import ChevronRight from '@material-ui/icons/ChevronRight';
import Clear from '@material-ui/icons/Clear';
import DeleteOutline from '@material-ui/icons/DeleteOutline';
import Edit from '@material-ui/icons/Edit';
import FilterList from '@material-ui/icons/FilterList';
import FirstPage from '@material-ui/icons/FirstPage';
import LastPage from '@material-ui/icons/LastPage';
import Remove from '@material-ui/icons/Remove';
import SaveAlt from '@material-ui/icons/SaveAlt';
import Search from '@material-ui/icons/Search';
import ViewColumn from '@material-ui/icons/ViewColumn';
import Button from "@material-ui/core/Button";
import TextField from '@material-ui/core/TextField';
import Dialog from '@material-ui/core/Dialog';
import DialogActions from '@material-ui/core/DialogActions';
import DialogContent from '@material-ui/core/DialogContent';
import DialogContentText from '@material-ui/core/DialogContentText';
import DialogTitle from '@material-ui/core/DialogTitle';
import DateFnsUtils from '@date-io/date-fns';
import {
    MuiPickersUtilsProvider,
    KeyboardDatePicker,
} from '@material-ui/pickers';


const tableIcons = {
    Add: forwardRef((props, ref) => <AddBox {...props} ref={ref} />),
    Check: forwardRef((props, ref) => <Check {...props} ref={ref} />),
    Clear: forwardRef((props, ref) => <Clear {...props} ref={ref} />),
    Delete: forwardRef((props, ref) => <DeleteOutline {...props} ref={ref} />),
    DetailPanel: forwardRef((props, ref) => <ChevronRight {...props} ref={ref} />),
    Edit: forwardRef((props, ref) => <Edit {...props} ref={ref} />),
    Export: forwardRef((props, ref) => <SaveAlt {...props} ref={ref} />),
    Filter: forwardRef((props, ref) => <FilterList {...props} ref={ref} />),
    FirstPage: forwardRef((props, ref) => <FirstPage {...props} ref={ref} />),
    LastPage: forwardRef((props, ref) => <LastPage {...props} ref={ref} />),
    NextPage: forwardRef((props, ref) => <ChevronRight {...props} ref={ref} />),
    PreviousPage: forwardRef((props, ref) => <ChevronLeft {...props} ref={ref} />),
    ResetSearch: forwardRef((props, ref) => <Clear {...props} ref={ref} />),
    Search: forwardRef((props, ref) => <Search {...props} ref={ref} />),
    SortArrow: forwardRef((props, ref) => <ArrowUpward {...props} ref={ref} />),
    ThirdStateCheck: forwardRef((props, ref) => <Remove {...props} ref={ref} />),
    ViewColumn: forwardRef((props, ref) => <ViewColumn {...props} ref={ref} />)
};

export class MealItemTable extends Component {

    constructor(props) {
        super(props);
        this.state = {
            mealItens: [],
            createMealItemDialog: false,
            selectedDate: '01/01/2019',
            errorText: ''
        };
        this.handleOpenCreateMealItemDialog = this.handleOpenCreateMealItemDialog.bind(this);
        this.handleOpenCloseMealItemDialog = this.handleOpenCloseMealItemDialog.bind(this);
    }

    handleOpenCreateMealItemDialog(){
        this.setState({
            createMealItemDialog: true
        })
    }

    handleOpenCloseMealItemDialog(){
        this.setState({
            createMealItemDialog: false
        })
    }

    handleCreateMealItem(){

    };

    deleteMealItens = (mealItemID) => {
        axios.delete('https://gorgeousfoodapi.azurewebsites.net/api/mealitem/' + mealItemID).then(() => {
            this.setState({
                mealItens: this.fetchMealItens()
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


    handleDateChange = (date) => {
        this.setState({
            selectedDate: date
        });
    };

    render() {

         let columns= [
              {title: 'Production Date', field: 'productionDate', type: 'datetime'},
              {title: 'Expiration Date', field: 'expirationDate', type: 'datetime' },
              {title: 'Meal Description', field: 'meal.description'}];



        return(

            <div className="ItemMealComponent">
                <grid>
                    <Button
                        variant="text"
                        color="default"
                        className="button"
                        onClick={this.handleOpenCreateMealItemDialog}
                        startIcon={<AddBox/>}>
                        Add Meal Item
                    </Button>
                    <Dialog open={this.state.createMealItemDialog} onClose={this.handleOpenCloseMealItemDialog} aria-labelledby="form-dialog-title"
                    className="">
                        <DialogTitle id="form-dialog-title">Create Meal Item</DialogTitle>
                        <DialogContent>
                            <DialogContentText>
                                To create a Meal Item, please fill in the following fields.
                            </DialogContentText>
                            <MuiPickersUtilsProvider utils={DateFnsUtils}>
                                    <KeyboardDatePicker
                                        margin="normal"
                                        id="date-picker-dialog"
                                        label="Date picker dialog"
                                        format="dd/MM/yyyy"
                                        value={this.state.selectedDate}
                                        onChange={this.handleDateChange}
                                        KeyboardButtonProps={{
                                            'aria-label': 'change date',
                                        }}
                                    />
                            </MuiPickersUtilsProvider>


                        </DialogContent>
                        <DialogActions>
                            <Button onClick={this.handleOpenCloseMealItemDialog} color="primary">
                                Cancel
                            </Button>
                            <Button onClick={this.handleOpenCloseMealItemDialog} color="primary">
                                Create
                            </Button>
                        </DialogActions>
                    </Dialog>
                </grid>

                <MaterialTable
                    title="Meal Itens"
                    columns={columns}
                    icons={tableIcons}
                    options={{
                        paging: false,
                        search: false,
                    }}
                    data={this.state.mealItens}
                    editable={{
                        onRowDelete: oldData =>
                            new Promise(resolve => {
                                setTimeout(() => {
                                    resolve();
                                    this.deleteMealItens(oldData.mealItemID);
                                    this.setState(this.fetchMealItens)
                                }, 600);
                            }),
                    }}
                />

            </div>
        );
    }
}

export default MealItemTable;