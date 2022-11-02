import { Table } from 'reactstrap'
import React, { useEffect, useState } from "react";
const TablaEnfrentamiento = () => {
    const [Enfrentamiento, setEnfrentamiento] = useState([])
    const MostrarEnfrentamiento = async () => {
        const responde = await fetch("api/api/enfrentamientos")
        if (responde.ok) {
            const data = await responde.json();
            setEnfrentamiento(data);
        } else {
            console.log('error en heroe')
        }

    }
    
    useEffect(() => {
        MostrarEnfrentamiento()
    }, []);
    return (
        <Table striped responsive>
            <thead>
                <tr>
                    <th>IdRegistro</th>
                    <th>IdHero</th>
                    <th>IdVillain</th>
                    <th>Resultado</th>
                </tr>
            </thead>
            <tbody>
                {
                    Enfrentamiento.map((x) => (
                        <tr>
                            {<>
                                <td>{x.idRegistro} </td>
                                <td>{x.idHero} </td>
                                <td>{x.idVillain} </td>
                                <td>{x.resultado} </td>
                                </>
                                }
                        </tr>

                        ))
                }

            </tbody>
        </Table>
        
        )
}



export default TablaEnfrentamiento;