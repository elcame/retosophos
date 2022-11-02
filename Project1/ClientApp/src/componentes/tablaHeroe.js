import { Table } from 'reactstrap'
import React, { useEffect, useState } from "react";
import TablaRelacion from "./tablaRelaciones";
const TablaHeroe = () => {
    const [Heroe, setHeroe] = useState([])
    const MostrarHeroe = async () => {
        const responde = await fetch("api/api/Lista")
        if (responde.ok) {
            const data = await responde.json();
            setHeroe(data);
            console.log(Heroe);
        } else {
            console.log('error en heroe')
        }

    }
   
    const [datos, setdatos] = useState(true)
    useEffect(() => {
        MostrarHeroe()
    }, []);

    return (
        <Table striped responsive>
            <thead>
                <tr>
                    <th>IdHero</th>
                    <th>NombreCompleto</th>
                    <th>Edad</th>
                    <th>HabilidadesPoderes</th>
                    <th>Debilidades</th>
                    <th>Disponibilidad</th>
                    <th>Relaciones</th>

                    
                </tr>
            </thead>
            <tbody>
                {   
                    Heroe.map((x) => (
                        <tr>
                            {   
                                <>
                                <td>{x.idHero} </td>
                                <td>{ x.nombreCompleto} </td>
                                <td>{ x.edad} </td>
                                <td>{ x.habilidadesPoderes} </td>
                                <td>{ x.debilidades} </td>
                                    <td>{x.Disponibilidad} </td>
 


                                    <button > 
                                        <TablaRelacion data={"api/api/relaciones/" + x.idHero}> relaciones </TablaRelacion>  </button> 
                                </>
                                }
                        </tr>

                        ))
                }

            </tbody>
        </Table>
        
        )
}



export default TablaHeroe;