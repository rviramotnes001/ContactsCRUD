import { Col, Container, Row, Card, CardHeader, CardBody, Button } from 'reactstrap';
import { useEffect, useState } from 'react';
import axios from 'axios';
import ContactTable from './components/ContactTable';

const App = () => {

    const [contacts, setContacts] = useState([]);

    useEffect(() => {
        getContacts();
    }, []);

    const getContacts = async () => {
        await axios.get("api/contact/GetAllContacts").then((response) => {
            const data = response.data;
            setContacts(data);
        }).catch((error) => {
            console.log(error);
        });
    }   



return (
        <Container>
        <Row className="mt-5">
            <Col sm="12">
                <Card>
                    <CardHeader>
                        <h5>Contact List</h5>
                    </CardHeader>
                    <CardBody>
                        <Button size="small" color="success">New Contact</Button>
                        <hr></hr>
                        <ContactTable contactData={contacts} />
                    </CardBody>
                </Card>
            </Col>
        </Row>
        </Container>
    );
}

export default App;