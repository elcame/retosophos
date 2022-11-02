import { Table } from 'reactstrap'
import React, { useEffect, useState } from "react";
const TablaRelacionesheroe = () => {
    const [Relaciones, setRelaciones] = useState([])
    const MostrarRelaciones = async () => {
        const responde = await fetch("api/api/relacionesheroe")
        if (responde.ok) {
            const data = await responde.json();
            setRelaciones(data);
        } else {
            console.log('error en heroe')
        }

    }


    useEffect(() => {
        MostrarRelaciones()
    }, []);
    return (
        <Table striped responsive>
            <thead>
                <tr>
                    <th>IdRelacion</th>
                    <th>IdHero</th>
                    <th>Tipo</th>
                    <th>Contacto</th>
                </tr>
            </thead>
            <tbody>
                {
                    Relaciones.map((x) => (
                        <tr>
                            {<>
                                <td>{x.idRelacion} </td>
                                <td>{x.idHero} </td>
                                <td>{x.tipo} </td>
                                <td>{x.contacto} </td>
                            </>
                            }
                        </tr>

                    ))
                }

            </tbody>
        </Table>

    )
}



export default TablaRelacionesheroe;