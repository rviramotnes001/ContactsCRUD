import { Table, Button  } from 'reactstrap';


const ContactTable = ({ contactData }) => {
    console.log(contactData)
    return (
        <Table striped responsive>

            <thead>
                <tr>
                <th>Fullname</th>
                <th>Email</th>
                <th>Phone</th>
                <th></th>
                </tr>
            </thead>
                <tbody>
                    {
                        (contactData.length < 1) ? <tr><td colSpan="4">No Contacts</td></tr> :
                            contactData.map((contact) => (
                                <tr key={contact.id}>
                                    <td>{contact.fullname}</td>
                                    <td>{contact.email}</td>
                                    <td>{contact.phone}</td>
                                    <td>
                                        <Button size="small" color="info" className="me-2">Edit</Button>
                                        <Button size="small" color="danger">Delete</Button>
                                    </td>
                                </tr>
                            ))
                    }
                </tbody>
        </Table>
    )
}

export default ContactTable;