import { Table } from 'reactstrap'
import React, { useEffect, useState } from "react";
const Tablapatrocinador = () => {
    const [patrocinador, setpatrocinador] = useState([])
    const Mostrarpatrocinador = async () => {
        const responde = await fetch("api/api/patrocinador")
        if (responde.ok) {
            const data = await responde.json();
            setpatrocinador(data);
        } else {
            console.log('error en heroe')
        }

    }

    
    useEffect(() => {
        Mostrarpatrocinador()
    }, []);

    return (
        <Table striped responsive>
            <thead>
                <tr>
                    <th>IdPatrocinador</th>
                    <th>OrigenDinero</th>
                    <th>Nombre</th>
                </tr>
            </thead>
            <tbody>
                {
                    patrocinador.map((x) => (
                        <tr>
                            {<>
                                <td>{x.idPatrocinador} </td>
                                <td>{x.origenDinero} </td>
                                <td>{x.nombre} </td>
                                </>
                                }
                        </tr>

                        ))
                }

            </tbody>
        </Table>
        
        )
}



export default Tablapatrocinador;