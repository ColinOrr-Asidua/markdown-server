//  Custom JavaScript may be placed here

$(function () {

    /*  SAMPLE CODE: 
        Demonstrates how to replace Gherkin traceability annotations with links to 
        the documentation. This sample code assumes that the annotations take the 
        format '@Jxxx' and the link to anchors in 'Journey.md#Jxxx'
                
    //  Add traceability links to annotations in a Gherkin feature file
    $('code.gherkin_en span.annotation:contains(@J)').each(function () {
        var annotation = $(this);
        var reference = annotation.text().trim().replace('@', '');
        annotation.replaceWith("<a href='Journeys.md#" + reference + "'>" + annotation.text() + "</a>");
    });

    */
});