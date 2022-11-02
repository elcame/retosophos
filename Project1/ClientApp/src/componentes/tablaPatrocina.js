import { Table } from 'reactstrap'
import React, { useEffect, useState } from "react";
const Tablapatrocina = () => {
    const [patrocina, setpatrocina] = useState([])
    const Mostrarpatrocina = async () => {
        const responde = await fetch("api/api/patrocina")
        if (responde.ok) {
            const data = await responde.json();
            setpatrocina(data);
        } else {
            console.log('error en heroe')
        }

    }

    
    useEffect(() => {
        Mostrarpatrocina()
    }, []);

    return (
        <Table striped responsive>
            <thead>
                <tr>
                    <th>IdPatrocinio</th>
                    <th>IdPatrocinador</th>
                    <th>IdHero</th>
                    <th>Monto</th>
                </tr>
            </thead>
            <tbody>
                {
                    patrocina.map((x) => (
                        <tr>
                            {<>
                                <td>{x.idPatrocinio} </td>
                                <td>{x.idPatrocinador} </td>
                                <td>{x.idHero} </td>
                                <td>{x.monto} </td>
                                </>
                                }
                        </tr>

                        ))
                }

            </tbody>
        </Table>
        
        )
}



export default Tablapatrocina;