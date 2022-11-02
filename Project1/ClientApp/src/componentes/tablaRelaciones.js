import { Table } from 'reactstrap'
import React, { useEffect, useState } from "react";
const TablaRelaciones = ({ data }) => {
    const [Relaciones, setRelaciones] = useState([])
    const MostrarRelaciones = async () => {
        const mesagge = "api/api/relaciones";
        console.log(data)
        if (data != null) {

            const responde = await fetch(data)
            if (responde.ok) {
                const data = await responde.json();
                setRelaciones(data);
            } else {
                console.log('error en heroe')
            }
        }
        if (data == null) { 
        const responde = await fetch(mesagge)
        if (responde.ok) {
            const data = await responde.json();
            setRelaciones(data);
        } else {
            console.log('error en heroe')
        }
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



export default TablaRelaciones;