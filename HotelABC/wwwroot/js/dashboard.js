$(() => {

    const $sidebar = $("#sidebar");
    const $toggleButton = $("#sidebarToggle");
    const $contentWrapper = $("#content-wrapper");

    $toggleButton.on("click", () => {
        $sidebar.toggleClass("collapsed");
        $contentWrapper.toggleClass("expanded");
    });

});