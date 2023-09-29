import { useRouter } from 'next/router';

function SpecificClientPage(){
    const router = useRouter();

    console.log(router.pathname); // the pathname string
    console.log(router.query); //the value of the query

    function loadProjectHandler() {
        // load data..
        //router.push('/clients/Eins/projectA');
        // OR
        router.push({
            pathname: '/clients/[id]/[clientprojectid]',
            query: { id: "Eins", clientprojectid: 'projectA' }
        });

    }
    return (
        <div>
            <h1>The Specific Client Page</h1>
            <button onClick={loadProjectHandler}>Load Project A</button>
        </div>
    );
}

export default SpecificClientPage;