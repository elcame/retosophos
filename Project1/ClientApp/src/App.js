import { Card,Col,Button, CardBody, CardHeader, Container, Row } from "reactstrap";
import TablaHeroe from "./componentes/tablaHeroe";
import Tablavillano from "./componentes/tablavillano";
import TablaEnfrentamiento from "./componentes/tablaEnfrentamiento";
import TablaPatrocinador from "./componentes/tablaPatrocinador";
import TablaPatrocina from "./componentes/tablaPatrocina";
import TablaRelacion from "./componentes/tablaRelaciones";
import { useState } from "react";
const app = () => {
    
    
    return (
        <>
        <Container>
            <Row>
                <Col sm='12'>
                    <Card>
                        <CardHeader>
                            <h5>Lista de heroes </h5>
                        </CardHeader>
                        <CardBody>
                            <Button size="sm" color="success">nuevo heroe</Button>
                            <hr></hr>
                            <TablaHeroe
                            />

                        </CardBody>

                    </Card>


                </Col>
            </Row>
        </Container>
         
        <Container>
            <Row>
                <Col sm='12'>
                    <Card>
                        <CardHeader>
                            <h5>Lista de villanos </h5>
                        </CardHeader>
                        <CardBody>
                            <Button size="sm" color="success">nuevo villano</Button>
                            <hr></hr>
                            <Tablavillano
                            />

                        </CardBody>

                    </Card>


                </Col>
                </Row>
        </Container>
         
        <Container>
            <Row>
                <Col sm='12'>
                    <Card>
                            <CardHeader>
                                <h5>Lista de Enfrentamientos </h5>
                            </CardHeader>
                            <CardBody>
                                <Button size="sm" color="success">nuevo Enfrentamiento </Button>
                                <hr></hr>
                                <TablaEnfrentamiento
                                />

                            </CardBody>

                        </Card>          


                    </Col>
                </Row>
            </Container>
           
            <Container>
                <Row>
                    <Col sm='12'>
                        <Card>
                            <CardHeader>
                                <h5>Lista de patrocinadores </h5>
                            </CardHeader>
                            <CardBody>
                                <Button size="sm" color="success">nuevo patrocinador</Button>
                                <hr></hr>
                                <TablaPatrocinador
                                />

                            </CardBody>

                        </Card>


                    </Col>
                </Row>
            </Container>

            <Container>
                <Row>
                    <Col sm='12'>
                        <Card>
                            <CardHeader>
                                <h5>Lista de patrocina </h5>
                            </CardHeader>
                            <CardBody>
                                <Button size="sm" color="success">nuevo patrocinio</Button>
                                <hr></hr>
                                <TablaPatrocina
                                />

                            </CardBody>

                        </Card>


                    </Col>
                </Row>
            </Container>

            <Container>
                <Row>
                    <Col sm='12'>
                        <Card>
                            <CardHeader>
                                <h5>Lista de relaciones </h5>
                            </CardHeader>
                            <CardBody>
                                <Button size="sm" color="success">nuevo relacion</Button>
                                <hr></hr>
                                <TablaRelacion
                                />

                            </CardBody>

                        </Card>


                    </Col>
                </Row>
            </Container>

        </>
    );
}
export default app;
