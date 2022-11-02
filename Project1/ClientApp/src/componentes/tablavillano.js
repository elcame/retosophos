import { Table } from 'reactstrap'
import React, { useEffect, useState } from "react";
const Tablavillano = () => {
    const [Villano, setvillano] = useState([])
    const MostrarVillano = async () => {
        const responde = await fetch("api/api/ListaV")
        if (responde.ok) {
            const data = await responde.json();
            setvillano(data);
        } else {
            console.log('error en villano')
        }

    }

    useEffect(() => {
        MostrarVillano()
    }, []);
    return (
        <Table striped responsive>
            <thead>
                <tr>
                    <th>IdVillain</th>
                    <th>NombreCompleto</th>
                    <th>Edad</th>
                    <th>HabilidadesPoderes</th>
                    <th>Debilidades</th>
                    <th>Origen</th>
                </tr>
            </thead>
            <tbody>
                {
                    Villano.map((x) => (
                        <tr>
                            {<>
                                <td>{x.idVillain} </td>
                                <td>{x.nombreCompleto} </td>
                                <td>{x.edad} </td>
                                <td>{x.habilidadesPoderes} </td>
                                <td>{x.debilidades} </td>
                                <td>{x.origen} </td>
                            </>
                            }
                        </tr>

                    ))
                }

            </tbody>
        </Table>

    )
}



export default Tablavillano;