import { useRouter } from 'next/router';

function PortfolioProjectPage() {
    const router = useRouter();

    console.log(router.pathname); // the pathname string
    console.log(router.query); //the value of the query

    //options
    //send a request to some backend server...
    //to fetch the piece of data with an id of router.query.projectid
    
    return (
        <div>
            <h1>The Portfolio Project Page</h1>
        </div>
    )
}

export default PortfolioProjectPage;