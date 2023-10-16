function UserProfilePage(props){
    return <h1>{props.username}</h1>
}

export default UserProfilePage;

export async function getServerSideProps(context) { //executes after the server
    const { params, req, res } = context;
    //              ^^^ from NodeJS Server
    console.log("Server Side Code");
    return {
        props: {
            username: 'Ryan'
        }
    }
}