﻿// ReSharper disable IdentifierTypo
// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo
// ReSharper disable StringLiteralTypo

namespace SqlParser;

internal static class Keywords
{
    /// <summary>
    /// Builds a list of SQL keywords from the enumeration
    /// </summary>
    static Keywords()
    {
        var renamedKeywords = new Dictionary<string, string>
        {
            {"END_EXEC", "END-EXEC"}
        };
        var keywords = Enum.GetNames(typeof(Keyword))
                .Where(n => n != nameof(Keyword.undefined))
                .ToArray();

        foreach (var renamed in renamedKeywords)
        {
            var index = Array.FindIndex(keywords, k => k == renamed.Key);
            if (index > -1)
            {
                keywords[index] = renamed.Value;
            }
        }

        All = keywords.ToArray();
    }

    internal static readonly string[] All;

    /// These keywords can't be used as a table alias, so that `FROM table_name alias`
    /// can be parsed unambiguously without looking ahead.
    internal static readonly Keyword[] ReservedForColumnAlias = {
        // Reserved as both a table and a column alias:
        Keyword.WITH,
        Keyword.EXPLAIN,
        Keyword.ANALYZE,
        Keyword.SELECT,
        Keyword.WHERE,
        Keyword.GROUP,
        Keyword.SORT,
        Keyword.HAVING,
        Keyword.ORDER,
        Keyword.TOP,
        Keyword.LATERAL,
        Keyword.VIEW,
        Keyword.LIMIT,
        Keyword.OFFSET,
        Keyword.FETCH,
        Keyword.UNION,
        Keyword.EXCEPT,
        Keyword.INTERSECT,
        Keyword.CLUSTER,
        Keyword.DISTRIBUTE,
        Keyword.RETURNING,
        // Reserved only as a column alias in the `SELECT` clause
        Keyword.FROM,
        Keyword.INTO,
        Keyword.END,
    };

    /// Can't be used as a column alias, so that `SELECT Expression alias`
    /// can be parsed unambiguously without looking ahead.
    internal static readonly Keyword[] ReservedForTableAlias =
    {
        // Reserved as both a table and a column alias:
        Keyword.WITH,
        Keyword.EXPLAIN,
        Keyword.ANALYZE,
        Keyword.SELECT,
        Keyword.WHERE,
        Keyword.GROUP,
        Keyword.SORT,
        Keyword.HAVING,
        Keyword.ORDER,
        Keyword.PIVOT,
        Keyword.UNPIVOT,
        Keyword.TOP,
        Keyword.LATERAL,
        Keyword.VIEW,
        Keyword.LIMIT,
        Keyword.OFFSET,
        Keyword.FETCH,
        Keyword.UNION,
        Keyword.EXCEPT,
        Keyword.INTERSECT,
        // Reserved only as a table alias in the `FROM`/`JOIN` clauses:
        Keyword.ON,
        Keyword.JOIN,
        Keyword.INNER,
        Keyword.CROSS,
        Keyword.FULL,
        Keyword.LEFT,
        Keyword.RIGHT,
        Keyword.NATURAL,
        Keyword.USING,
        Keyword.CLUSTER,
        Keyword.DISTRIBUTE,
        // for MSSQL-specific OUTER APPLY (seems reserved in most dialects)
        Keyword.OUTER,
        Keyword.SET,
        Keyword.QUALIFY,
        Keyword.WINDOW,
        Keyword.END,
        Keyword.FOR,
        Keyword.AS // TODO remove?
    };
}

// ReSharper disable InconsistentNaming
public enum Keyword
{
    ABORT,
    ABS,
    ABSOLUTE,
    ACTION,
    ADD,
    ADMIN,
    AFTER,
    AGAINST,
    ALL,
    ALLOCATE,
    ALTER,
    ALWAYS,
    ANALYZE,
    AND,
    ANTI,
    ANY,
    APPLY,
    ARCHIVE,
    ARE,
    ARRAY,
    ARRAY_AGG,
    ARRAY_MAX_CARDINALITY,
    AS,
    ASC,
    ASENSITIVE,
    ASSERT,
    ASYMMETRIC,
    AT,
    ATOMIC,
    ATTACH,
    AUTHORIZATION,
    AUTO,
    AUTO_INCREMENT,
    AUTOINCREMENT,
    AVG,
    AVRO,
    BACKWARD,
    BASE64,
    BEGIN,
    BEGIN_FRAME,
    BEGIN_PARTITION,
    BETWEEN,
    BIGINT,
    BIGNUMERIC,
    BINARY,
    BINDING,
    BLOB,
    BOOL,
    BOOLEAN,
    BOTH,
    BROWSE,
    BTREE,
    BY,
    BYPASSRLS,
    BYTEA,
    BYTES,
    CACHE,
    CALL,
    CALLED,
    CARDINALITY,
    CASCADE,
    CASCADED,
    CASE,
    CAST,
    CEIL,
    CEILING,
    CENTURY,
    CHAIN,
    CHANGE,
    CHANNEL,
    CHAR,
    CHAR_LENGTH,
    CHARACTER,
    CHARACTER_LENGTH,
    CHARACTERS,
    CHARSET,
    CHECK,
    CLOB,
    CLONE,
    CLOSE,
    CLUSTER,
    COALESCE,
    COLLATE,
    COLLATION,
    COLLECT,
    COLLECTION,
    COLUMN,
    COLUMNS,
    COMMENT,
    COMMIT,
    COMMITTED,
    COMPRESSION,
    COMPUTE,
    CONCURRENTLY,
    CONDITION,
    CONFLICT,
    CONNECT,
    CONNECTION,
    CONSTRAINT,
    CONTAINS,
    CONVERT,
    COPY,
    COPY_OPTIONS,
    CORR,
    CORRESPONDING,
    COUNT,
    COVAR_POP,
    COVAR_SAMP,
    CREATE,
    CREATEDB,
    CREATEROLE,
    CREDENTIALS,
    CROSS,
    CSV,
    CUBE,
    CUME_DIST,
    CURRENT,
    CURRENT_CATALOG,
    CURRENT_DATE,
    CURRENT_DEFAULT_TRANSFORM_GROUP,
    CURRENT_PATH,
    CURRENT_ROLE,
    CURRENT_ROW,
    CURRENT_SCHEMA,
    CURRENT_TIME,
    CURRENT_TIMESTAMP,
    CURRENT_TRANSFORM_GROUP_FOR_TYPE,
    CURRENT_USER,
    CURSOR,
    CYCLE,
    DATA,
    DATABASE,
    DATE,
    DATETIME,
    DAY,
    DAYOFWEEK,
    DAYOFYEAR,
    DEALLOCATE,
    DEC,
    DECADE,
    DECIMAL,
    DECLARE,
    DEFAULT,
    DEFERRABLE,
    DEFERRED,
    DEFINED,
    DELAYED,
    DELETE,
    DELIMITED,
    DELIMITER,
    DENSE_RANK,
    DEREF,
    DESC,
    DESCRIBE,
    DETERMINISTIC,
    DIRECTORY,
    DISABLE,
    DISCARD,
    DISCONNECT,
    DISTINCT,
    DISTRIBUTE,
    DIV,
    DO,
    DOUBLE,
    DOW,
    DOY,
    DROP,
    DUPLICATE,
    DYNAMIC,
    EACH,
    ELEMENT,
    ELEMENTS,
    ELSE,
    EMPTY,
    ENABLE,
    ENCODING,
    ENCRYPTION,
    END,
    END_FRAME,
    END_PARTITION,
    ENFORCED,
    END_EXEC,
    ENDPOINT,
    ENGINE,
    ENUM,
    EPOCH,
    EQUALS,
    ERROR,
    ESCAPE,
    ESCAPED,
    EVENT,
    EVERY,
    EXCEPT,
    EXCEPTION,
    EXCLUDE,
    EXCLUSIVE,
    EXEC,
    EXECUTE,
    EXISTS,
    EXP,
    EXPANSION,
    EXPLAIN,
    EXPLICIT,
    EXPORT,
    EXTENDED,
    EXTENSION,
    EXTERNAL,
    EXTRACT,
    FAIL,
    FALSE,
    FETCH,
    FIELDS,
    FILE,
    FILES,
    FILE_FORMAT,
    FILTER,
    FIRST,
    FIRST_VALUE,
    FLOAT,
    FLOAT4,
    FLOAT64,
    FLOAT8,
    FLOOR,
    FLUSH,
    FOLLOWING,
    FOR,
    FORCE,
    FORCE_NOT_NULL,
    FORCE_NULL,
    FORCE_QUOTE,
    FOREIGN,
    FORMAT,
    FORMATTED,
    FORWARD,
    FRAME_ROW,
    FREE,
    FREEZE,
    FROM,
    FULL,
    FULLTEXT,
    FUNCTION,
    FUNCTIONS,
    FUSION,
    GENERAL,
    GENERATED,
    GEOGRAPHY,
    GET,
    GLOBAL,
    GRANT,
    GRANTED,
    GRAPHVIZ,
    GROUP,
    GROUPING,
    GROUPS,
    HASH,
    HAVING,
    HEADER,
    HIGH_PRIORITY,
    HIVEVAR,
    HOLD,
    HOSTS,
    HOUR,
    IDENTITY,
    IF,
    IGNORE,
    ILIKE,
    IMMEDIATE,
    IMMUTABLE,
    IN,
    INCLUDE,
    INCLUDE_NULL_VALUES,
    INCREMENT,
    INDEX,
    INDICATOR,
    INHERIT,
    INITIALLY,
    INNER,
    INOUT,
    INPUT,
    INPUTFORMAT,
    INSENSITIVE,
    INSERT,
    INSTALL,
    INT,
    INT2,
    INT4,
    INT64,
    INT8,
    INTEGER,
    INTERSECT,
    INTERSECTION,
    INTERVAL,
    INTO,
    IS,
    ISODOW,
    ISOLATION,
    ISOWEEK,
    ISOYEAR,
    ITEMS,
    JAR,
    JOIN,
    JSON,
    JSONB,
    JSONFILE,
    JSON_TABLE,
    JULIAN,
    KEY,
    KEYS,
    KILL,
    LAG,
    LANGUAGE,
    LARGE,
    LAST,
    LAST_VALUE,
    LATERAL,
    LEAD,
    LEADING,
    LEFT,
    LEVEL,
    LIKE,
    LIKE_REGEX,
    LIMIT,
    LINES,
    LISTAGG,
    LN,
    LOAD,
    LOCAL,
    LOCALTIME,
    LOCALTIMESTAMP,
    LOCATION,
    LOCK,
    LOCKED,
    LOGIN,
    LOGS,
    LOWER,
    LOW_PRIORITY,
    MACRO,
    MANAGEDLOCATION,
    MAP,
    MATCH,
    MATCHED,
    MATERIALIZED,
    MAX,
    MAXVALUE,
    MEDIUMINT,
    MEMBER,
    MERGE,
    METADATA,
    METHOD,
    MICROSECOND,
    MICROSECONDS,
    MILLENIUM,
    MILLENNIUM,
    MILLISECOND,
    MILLISECONDS,
    MIN,
    MINUTE,
    MINVALUE,
    MOD,
    MODE,
    MODIFIES,
    MODULE,
    MONTH,
    MSCK,
    MULTISET,
    MUTATION,
    NAME,
    NANOSECOND,
    NANOSECONDS,
    NATIONAL,
    NATURAL,
    NCHAR,
    NCLOB,
    NEW,
    NEXT,
    NO,
    NOBYPASSRLS,
    NOCREATEDB,
    NOCREATEROLE,
    NOINHERIT,
    NOLOGIN,
    NONE,
    NOREPLICATION,
    NORMALIZE,
    NOSCAN,
    NOSUPERUSER,
    NOT,
    NOTHING,
    NOWAIT,
    NO_WRITE_TO_BINLOG,
    NTH_VALUE,
    NTILE,
    NULL,
    NULLIF,
    NULLS,
    NUMERIC,
    NVARCHAR,
    OBJECT,
    OCCURRENCES_REGEX,
    OCTET_LENGTH,
    OCTETS,
    OF,
    OFFSET,
    OLD,
    ON,
    ONLY,
    OPEN,
    OPERATOR,
    OPTIMIZER_COSTS,
    OPTION,
    OPTIONS,
    OR,
    ORC,
    ORDER,
    OUT,
    OUTER,
    OUTPUTFORMAT,
    OVER,
    OVERFLOW,
    OVERLAPS,
    OVERLAY,
    OVERWRITE,
    OWNED,
    PARALLEL,
    PARAMETER,
    PARQUET,
    PARTITION,
    PARTITIONED,
    PARTITIONS,
    PASSWORD,
    PATH,
    PATTERN,
    PERCENT,
    PERCENT_RANK,
    PERCENTILE_CONT,
    PERCENTILE_DISC,
    PERIOD,
    PIVOT,
    PLACING,
    PLANS,
    PORTION,
    POSITION,
    POSITION_REGEX,
    POWER,
    PRAGMA, 
    PRECEDES,
    PRECEDING,
    PRECISION,
    PREPARE,
    PRESERVE,
    PRIMARY,
    PRIOR,
    PRIVILEGES,
    PROCEDURE,
    PROGRAM,
    PURGE,
    QUALIFY,
    QUARTER,
    QUERY,
    QUOTE,
    RANGE,
    RANK,
    RAW,
    RCFILE,
    READ,
    READS,
    REAL,
    RECURSIVE,
    REF,
    REFERENCES,
    REFERENCING,
    REGCLASS,
    REGEXP,
    REGR_AVGX,
    REGR_AVGY,
    REGR_COUNT,
    REGR_INTERCEPT,
    REGR_R2,
    REGR_SLOPE,
    REGR_SXX,
    REGR_SXY,
    REGR_SYY,
    RELATIVE,
    RELAY,
    RELEASE,
    RENAME,
    REPAIR,
    REPEATABLE,
    REPLACE,
    REPLICA,
    REPLICATION,
    RESET,
    RESPECT,
    RESTRICT,
    RESTRICTED,
    RESULT,
    RESULTSET,
    RETURN,
    RETURNING,
    RETURNS,
    REVOKE,
    RIGHT,
    RLIKE,
    ROLE,
    ROLLBACK,
    ROLLUP,
    ROOT,
    ROW,
    ROW_NUMBER,
    RULE,
    ROWID,
    ROWS,
    SAFE,
    SAFE_CAST,
    SAVEPOINT,
    SCHEMA,
    SCOPE,
    SCROLL,
    SEARCH,
    SECOND,
    SECURITY,
    SELECT,
    SEMI,
    SENSITIVE,
    SEQUENCE,
    SEQUENCEFILE,
    SEQUENCES,
    SERDE,
    SERDEPROPERTIES,
    SERIALIZABLE,
    SESSION,
    SESSION_USER,
    SET,
    SETS,
    SHARE,
    SHOW,
    SIMILAR,
    SKIP,
    SLOW,
    SMALLINT,
    SNAPSHOT,
    SOME,
    SORT,
    SPATIAL,
    SPECIFIC,
    SPECIFICTYPE,
    SQL,
    SQLEXCEPTION,
    SQLSTATE,
    SQLWARNING,
    SQRT,
    STABLE,
    STAGE,
    START,
    STATIC,
    STATISTICS,
    STATUS,
    STDDEV_POP,
    STDDEV_SAMP,
    STDIN,
    STDOUT,
    STORAGE_INTEGRATION,
    STORED,
    STRICT,
    STRING,
    STRUCT,
    SUBMULTISET,
    SUBSTRING,
    SUBSTRING_REGEX,
    SUCCEEDS,
    SUM,
    SUPER,
    SUPERUSER,
    SWAP,
    SYMMETRIC,
    SYNC,
    SYSTEM,
    SYSTEM_TIME,
    SYSTEM_USER,
    TABLE,
    TABLES,
    TABLESAMPLE,
    TBLPROPERTIES,
    TEMP,
    TEMPORARY,
    TERMINATED,
    TEXT,
    TEXTFILE,
    THEN,
    TIES,
    TIME,
    TIMESTAMP,
    TIMESTAMPTZ,
    TIMETZ,
    TIMEZONE,
    TIMEZONE_ABBR,
    TIMEZONE_HOUR,
    TIMEZONE_MINUTE,
    TIMEZONE_REGION,
    TINYINT,
    TO,
    TOP,
    TRAILING,
    TRANSACTION,
    TRANSIENT,
    TRANSLATE,
    TRANSLATE_REGEX,
    TRANSLATION,
    TREAT,
    TRIGGER,
    TRIM,
    TRIM_ARRAY,
    TRUE,
    TRUNCATE,
    TRY_CAST,
    TYPE,
    UESCAPE,
    UNBOUNDED,
    UNCACHE,
    UNCOMMITTED,
    UNION,
    UNIQUE,
    UNKNOWN,
    UNLOAD,
    UNLOCK,
    UNLOGGED,
    UNNEST,
    UNPIVOT,
    UNSAFE,
    UNSIGNED,
    UNTIL,
    UPDATE,
    UPPER,
    URL,
    USAGE,
    USE,
    USER,
    USER_RESOURCES,
    USING,
    UUID,
    VALID,
    VALIDATION_MODE,
    VALUE,
    VALUE_OF,
    VALUES,
    VAR_POP,
    VAR_SAMP,
    VARBINARY,
    VARCHAR,
    VARIABLES,
    VARYING,
    VERBOSE,
    VERSION,
    VERSIONING,
    VIEW,
    VIRTUAL,
    VOLATILE,
    WEEK,
    WHEN,
    WHENEVER,
    WHERE,
    WIDTH_BUCKET,
    WINDOW,
    WITH,
    WITHIN,
    WITHOUT,
    WITHOUT_ARRAY_WRAPPER,
    WORK,
    WRITE,
    XML,
    XOR,
    YEAR,
    ZONE,

    undefined,
}