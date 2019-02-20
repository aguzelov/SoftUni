function validateRequest(obj) {
    let properties = ['method', 'uri', 'version', 'message'];
    let methodValues = ['GET', 'POST', 'DELETE', 'CONNECT'];
    let versionValues = ['HTTP/0.9', 'HTTP/1.0', 'HTTP/1.1', 'HTTP/2.0'];

    let validator = {
        method: (obj) => methodValues.indexOf(obj.method) !== -1,
        uri: (obj) => {
            let uri = obj.uri;
            let regex = new RegExp('^[\\w.]+$', 'g');
            return regex.test(uri);
        },
        version: (obj) => {
            return (typeof obj.version === 'string' || obj.version instanceof String) &&
                (versionValues.indexOf(obj.version) !== -1);
        },
        message: (obj) => {
            let message = obj.message;
            let regex = new RegExp('[<>\\\\&\'\"]', 'g');
            let testResult = regex.test(message);
            return !testResult;
        }
    };

    let errorMessage = 'Invalid request header: Invalid ';
    for (const property of properties) {
        if (!obj.hasOwnProperty(property) || !validator[property](obj)) {
            let propertyName = property[0].toUpperCase() + property.slice(1);

            if (property === 'uri') {
                propertyName = propertyName.toUpperCase();
            }
            throw new Error(errorMessage + propertyName);
        }
    }

    return obj;
}


console.log(
    validateRequest({
        method: 'GET',
        uri: 'svn.public.catalog',
        version: 'HTTP/1.1',
        message: 'asl\\pls'
    })

);
