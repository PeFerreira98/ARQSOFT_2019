import React from 'react';

const mealItem = (props) => {

    return(
        <tr>
            <td>{props.mealItemID}</td>
            <td>{props.productionDate}</td>
            <td>{props.expirationDate}</td>
            <td>{props.mealID}</td>
            <td>{props.description}</td>
        </tr>
    );
};

export default  mealItem;