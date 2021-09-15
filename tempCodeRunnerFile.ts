// MongoDB Playground
// Use Ctrl+Space inside a snippet or a string literal to trigger completions.

const database = 'PracticeAPI';
const collection = 'items';

// Create a new database.
use(database);

// Create a new collection.
db.createCollection(collection);

// The prototype form to create a regular collection:
/* db.createCollection( <name>,
  {
    capped: <boolean>,
    autoIndexId: <boolean>,
    size: <number>,
    max: <number>,
    storageEngine: <document>,
    validator: <document>,
    validationLevel: <string>,
    validationAction: <string>,
    indexOptionDefaults: <document>,
    viewOn: <string>,
    pipeline: <pipeline>,
    collation: <document>,
    writeConcern: <document>
  }
) */

// The prototype form to create a time-series collection:
/* db.createCollection( <name>,
  {
    timeseries: {
      timeField: <string>,
      metaField: <string>,
      expireAfterSeconds: <number>
    }
  }
) */
